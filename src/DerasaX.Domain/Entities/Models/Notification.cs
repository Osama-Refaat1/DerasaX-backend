using DerasaX.Domain.Entities.Base;
using DerasaX.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DerasaX.Domain.Entities.Models
{
    public class Notification : BaseEntity<string>
    {
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string? ActionUrl { get; set; }
        public NotificationCategory NotificationCategory { get; set; }
        public NotificationType NotificationType { get; set; } = NotificationType.System;
        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? MetadataJson { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
