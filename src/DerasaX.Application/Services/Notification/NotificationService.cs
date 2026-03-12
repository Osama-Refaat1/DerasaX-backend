using DerasaX.Application.Common;
using DerasaX.Application.Dto.NotificationDto;
using DerasaX.Application.Services.Abstractions.Notification;
using DerasaX.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DerasaX.Domain.Entities.Models;

namespace DerasaX.Application.Services.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRealtimeSender _realtimeSender;
        private readonly UserManager<ApplicationUser> _userManager;

        public NotificationService(
            IUnitOfWork unitOfWork,
            IRealtimeSender realtimeSender,
            UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _realtimeSender = realtimeSender;
            _userManager = userManager;
        }

        public async Task SendToUserAsync(string userId, NotificationDto dto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return;

            await PersistManyAsync(dto, [user]);

            try { await _realtimeSender.SendToUserAsync(userId, dto); }
            catch { /* realtime is best-effort; persistence already succeeded */ }
        }

        public async Task SendToTenantRoleAsync(string tenantId, string role, NotificationDto dto)
        {
            var tenantUsers = await _userManager.Users
                .Where(u => u.TenantId == tenantId)
                .ToListAsync();

            // Filter by role using a JOIN-friendly approach
            var usersInRole = new List<ApplicationUser>();
            foreach (var user in tenantUsers)
            {
                if (await _userManager.IsInRoleAsync(user, role))
                    usersInRole.Add(user);
            }

            await PersistManyAsync(dto, usersInRole);

            try { await _realtimeSender.SendToGroupAsync(RealtimeGroups.TenantRole(tenantId, role), dto); }
            catch { /* realtime is best-effort; persistence already succeeded */ }
        }

        public async Task SendAnnouncementAsync(string tenantId, NotificationDto dto)
        {
            var allUsers = await _userManager.Users
                .Where(u => u.TenantId == tenantId)
                .ToListAsync();

            await PersistManyAsync(dto, allUsers);

            try { await _realtimeSender.SendToGroupAsync(RealtimeGroups.TenantAll(tenantId), dto); }
            catch { /* realtime is best-effort; persistence already succeeded */ }
        }

        public async Task<IEnumerable<NotificationResponseDto>> GetNotificationsAsync(string userId, int page = 1, int pageSize = 20)
        {
            var spec = new Domain.Specification.NotificationByUserSpecification(userId, page, pageSize);
            var notifications = await _unitOfWork.Repository<Domain.Entities.Models.Notification, string>()
                .GetAllWithSpecAsync(spec);

            return notifications.Select(n => new NotificationResponseDto
            {
                Id = n.Id,
                Title = n.Title,
                Body = n.Body,
                ActionUrl = n.ActionUrl,
                Category = n.NotificationCategory,
                Type = n.NotificationType,
                IsRead = n.IsRead,
                CreatedAt = n.CreatedAt,
                MetadataJson = n.MetadataJson
            });
        }

        public async Task<int> GetUnreadCountAsync(string userId)
        {
            var spec = new Domain.Specification.UnreadNotificationCountSpecification(userId);
            return await _unitOfWork.Repository<Domain.Entities.Models.Notification, string>()
                .CountAsync(spec);
        }

        public async Task<bool> MarkAsReadAsync(string notificationId, string userId)
        {
            var notification = await _unitOfWork.Repository<Domain.Entities.Models.Notification, string>()
                .GetByIdAsync(notificationId);

            if (notification is null || notification.UserId != userId)
                return false;

            notification.IsRead = true;
            _unitOfWork.Repository<Domain.Entities.Models.Notification, string>().Update(notification);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task MarkAllReadAsync(string userId)
        {
            var spec = new Domain.Specification.AllNotificationsByUserSpecification(userId);
            var notifications = (await _unitOfWork.Repository<Domain.Entities.Models.Notification, string>()
                .GetAllWithSpecAsync(spec)).Where(n => !n.IsRead).ToList();

            foreach (var n in notifications)
                n.IsRead = true;

            // Bulk update: all changes tracked in the same context, single SaveChanges
            await _unitOfWork.SaveChangesAsync();
        }

        // ─────────────────────────────────────────────
        private async Task PersistManyAsync(NotificationDto dto, List<ApplicationUser> users)
        {
            if (users.Count == 0) return;

            var notifications = users.Select(u => new Domain.Entities.Models.Notification
            {
                Id = Guid.NewGuid().ToString(),
                Title = dto.Title,
                Body = dto.Body,
                ActionUrl = dto.ActionUrl,
                NotificationCategory = dto.Category,
                NotificationType = dto.Type,
                IsRead = false,
                CreatedAt = DateTime.UtcNow,
                MetadataJson = dto.MetadataJson,
                UserId = u.Id,
                TenantId = u.TenantId
            });

            await _unitOfWork.Repository<Domain.Entities.Models.Notification, string>()
                .AddRangeAsync(notifications);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

