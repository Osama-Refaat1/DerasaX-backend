using DerasaX.Application.Dto.NotificationDto;

namespace DerasaX.Application.Services.Abstractions.Notification
{
    public interface INotificationService
    {
        Task SendToUserAsync(string userId, NotificationDto dto);
        Task SendToTenantRoleAsync(string tenantId, string role, NotificationDto dto);
        Task SendAnnouncementAsync(string tenantId, NotificationDto dto);

        Task<IEnumerable<NotificationResponseDto>> GetNotificationsAsync(string userId, int page = 1, int pageSize = 20);
        Task<int> GetUnreadCountAsync(string userId);
        Task<bool> MarkAsReadAsync(string notificationId, string userId);
        Task MarkAllReadAsync(string userId);
    }
}
