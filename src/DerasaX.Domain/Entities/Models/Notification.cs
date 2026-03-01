using DerasaX.Domain.Entities.Base;
using DerasaX.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class Notification :BaseEntity<string>
    {
        public string Title { get; set; }        
        public string Body { get; set; }
        public string? ActionUrl { get; set; }
        public NotificationCategory notificationCategory { get; set; }
        public bool IsRead { get; set; } = false;
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public ApplicationUser User { get; set; }
        public TargetAudience? TargetAudience { get; set; }
    }
}
