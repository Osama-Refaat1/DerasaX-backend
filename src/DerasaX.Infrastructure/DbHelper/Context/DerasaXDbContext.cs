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
using DerasaX.Domain.Entities.Base;
using DerasaX.Application.Services.Abstractions;
using System.Linq.Expressions;

namespace DerasaX.Infrastructure.DbHelper.Context
{
    public class DerasaXDbContext(DbContextOptions<DerasaXDbContext> options): IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            

            // builder.ApplySoftDeleteQueryFilter();
            builder.ApplyEnumToStringConversions();
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //Table Per Type
            builder.Entity<Student>().ToTable("Student");
            builder.Entity<Teacher>().ToTable("Teacher");
            builder.Entity<Parent>().ToTable("Parent");
            builder.Entity<SystemAdmin>().ToTable("SystemAdmin");
            builder.Entity<SchoolAdmin>().ToTable("SchoolAdmin");

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(IMustHaveTenant).IsAssignableFrom(entityType.ClrType))
                {
                     builder.Entity(entityType.ClrType)
                     .HasIndex("TenantId");
                }
            }
            
        }
        public DbSet<Announcement> announcements { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Parent> parents { get; set; }
        public DbSet<SystemAdmin> systemAdmins { get; set; }
        public DbSet<SchoolAdmin> SchoolAdmin { get; set; }
        public DbSet<Unit> units { get; set; }
        public DbSet<Grade> grades { get; set; }
        public DbSet<GradeSubject> gradeSubjects { get; set; }
        public DbSet<Lesson> lessons { get; set; }
        public DbSet<LessonMaterial> lessonMaterials { get; set; }
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
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }

    }
}
