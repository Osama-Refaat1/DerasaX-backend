using DerasaX.Application.Services.Abstractions.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DerasaX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET /api/notifications?page=1&pageSize=20
        [HttpGet]
        public async Task<IActionResult> GetNotifications([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            if (page < 1) page = 1;
            if (pageSize < 1 || pageSize > 100) pageSize = 20;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            var notifications = await _notificationService.GetNotificationsAsync(userId, page, pageSize);
            return Ok(notifications);
        }

        // GET /api/notifications/unread-count
        [HttpGet("unread-count")]
        public async Task<IActionResult> GetUnreadCount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            var count = await _notificationService.GetUnreadCountAsync(userId);
            return Ok(new { unreadCount = count });
        }

        // PATCH /api/notifications/{id}/read
        [HttpPatch("{id}/read")]
        public async Task<IActionResult> MarkAsRead(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            var success = await _notificationService.MarkAsReadAsync(id, userId);
            if (!success) return NotFound();

            return NoContent();
        }

        // PATCH /api/notifications/read-all
        [HttpPatch("read-all")]
        public async Task<IActionResult> MarkAllRead()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            await _notificationService.MarkAllReadAsync(userId);
            return NoContent();
        }
    }
}
