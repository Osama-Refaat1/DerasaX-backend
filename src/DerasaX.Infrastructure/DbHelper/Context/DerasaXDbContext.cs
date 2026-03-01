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
    public class DerasaXDbContext: IdentityDbContext<ApplicationUser>
    {
        
        private readonly ITenantService _tenantService;
        public DerasaXDbContext(DbContextOptions options,ITenantService tenantService) : base(options)
        {
            _tenantService=tenantService;
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
            ApplyTenantQueryFilter(builder);
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
        private void ApplyTenantQueryFilter(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(IMustHaveTenant).IsAssignableFrom(entityType.ClrType))
                {
                    builder.Entity(entityType.ClrType)
                        .HasQueryFilter(CreateTenantFilterExpression(entityType.ClrType));
                }
            }
        }
        private LambdaExpression CreateTenantFilterExpression(Type entityType)
        {
            var parameter = Expression.Parameter(entityType, "e");

            var tenantProperty = Expression.Property(parameter, "TenantId");

            var tenantServiceExpression =
                Expression.Constant(this);

            var currentTenantMethod =
                typeof(DerasaXDbContext)
                .GetMethod(nameof(GetCurrentTenantId),
                    BindingFlags.NonPublic | BindingFlags.Instance);

            var tenantIdExpression =
                Expression.Call(tenantServiceExpression, currentTenantMethod);

            var body = Expression.Equal(tenantProperty, tenantIdExpression);

            return Expression.Lambda(body, parameter);
        }
        private string GetCurrentTenantId()
        {
            var tenant = _tenantService.GetCurrentTenant();
            return tenant?.Id ?? throw new Exception("Tenant is required.");
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<IMustHaveTenant>().Where(e=>e.State==EntityState.Added))
            {
                entry.Entity.TenantId = _tenantService.GetCurrentTenant().Id;
            }
            return base.SaveChangesAsync(cancellationToken);
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
    }
}
