using DerasaX.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public UserRole UserRole { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Gender Gender { get; set; }
        [ForeignKey("Tenant")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        [ForeignKey("Grade")]
        public Guid GradeId { get; set; }
        public Grade Grade { get; set; }
        public ICollection<QuizSubmission> quizSubmissions { get; set; } = new HashSet<QuizSubmission>();
        public ICollection<StudentLessonProgress> studentLessonProgresses { get; set; } = new HashSet<StudentLessonProgress>();
        public ICollection<StudentInsight> studentInsights { get; set; } = new HashSet<StudentInsight>();
        public ICollection<Post> posts { get; set; } = new HashSet<Post>();
        public ICollection<Notification> notifications { get; set; } = new HashSet<Notification>();
        public ICollection<SupportRequest> supportRequests { get; set; } = new HashSet<SupportRequest>();
        public ICollection<Announcement> Announcements { get; set; } = new HashSet<Announcement>();
    }
}
