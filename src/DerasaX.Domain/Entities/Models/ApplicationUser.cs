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
        //public UserRole UserRole { get; set; }
        public string LoginCode { get; set; }
        [ForeignKey("Tenant")]
        public string TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Gender? Gender { get; set; }
        public List<RefreshToken>? refreshTokens { get; set; }
        public ICollection<Post> posts { get; set; } = new HashSet<Post>();
        public ICollection<Notification> notifications { get; set; } = new HashSet<Notification>();
        public ICollection<SupportRequest> supportRequests { get; set; } = new HashSet<SupportRequest>();
    }
    public class Student:ApplicationUser
    {
        [ForeignKey("Grade")]
        public string GradeId { get; set; }
        public Grade Grade { get; set; }
        public ICollection<StudentInsight> studentInsights { get; set; } = new HashSet<StudentInsight>();
        public ICollection<StudentLessonProgress> studentLessonProgresses { get; set; } = new HashSet<StudentLessonProgress>();
        public ICollection<QuizSubmission> quizSubmissions { get; set; } = new HashSet<QuizSubmission>();

    }
    public class Teacher : ApplicationUser
    {
    }
    public class Parent : ApplicationUser
    {
    }
    public class SchoolAdmin : ApplicationUser
    {
    }
    public class SystemAdmin:ApplicationUser
    {
    }

}
