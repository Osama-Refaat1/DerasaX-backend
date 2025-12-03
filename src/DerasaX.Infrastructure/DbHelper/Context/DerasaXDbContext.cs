using DerasaX.Domain.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DerasaX.Infrastructure.configuration;

namespace DerasaX.Infrastructure.DbHelper.Context
{
    public class DerasaXDbContext(DbContextOptions<DerasaXDbContext> options): IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplySoftDeleteQueryFilter();
            builder.ApplyEnumToStringConversions();
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Announcement> announcements { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Curriculums> curriculums { get; set; }
        public DbSet<Grade> grades { get; set; }
        public DbSet<GradeSubject> gradeSubjects { get; set; }
        public DbSet<Lesson> lessons { get; set; }
        public DbSet<LessonAttachment> lessonAttachments { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<QuestionOption> questionOptions { get; set; }
        public DbSet<Quiz> quizzes { get; set; }
        public DbSet<QuizGeneration> quizGenerations { get; set; }
        public DbSet<QuizSubmission> quizSubmissions { get; set; }
        public DbSet<StudentInsight> studentInsights { get; set; }
        public DbSet<StudentLessonProgress> studentLessonProgresses { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<SubmissionAnswer> submissionAnswers { get; set; }
        public DbSet<SupportRequest> supportRequests { get; set; }
        public DbSet<Tenant> tenants { get; set; }
    }
}
