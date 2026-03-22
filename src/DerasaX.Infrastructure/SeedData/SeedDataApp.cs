using DerasaX.Domain.Entities.Models;
using DerasaX.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Infrastructure.SeedData
{
    public class SeedDataApp
    {
        public static void Seed(ModelBuilder builder)
        {
            SeedTenants(builder);
            SeedSecurityQuestions(builder);
            SeedGrades(builder);
        }
         //Tenants
        private static void SeedTenants(ModelBuilder builder)
        {
            builder.Entity<Tenant>().HasData(
                new Tenant
                {
                    Id            = "tenant-1",
                    Name          = "Al Nour School",
                    Domain        = "alnour.derasax.com",
                    SubscriptionPlan = SubscriptionPlan.Pro,
                    LogoUrl       = null,
                    Address       = "Cairo, Egypt",
                    Phone         = "0201000000001",
                    Type          = CurriculumType.Egyptian
                }
            );
        }
        //Security Questions
        private static void SeedSecurityQuestions(ModelBuilder builder)
        {
            builder.Entity<SecurityQuestion>().HasData(
                new SecurityQuestion { Id = 1, Question = "What was your childhood nickname?", IsDeleted = false },
                new SecurityQuestion { Id = 2, Question = "What is your mother's maiden name?" , IsDeleted = false },
                new SecurityQuestion { Id = 3, Question = "In which city were you born?", IsDeleted = false }
            );
        }
        //Grades
        private static void SeedGrades(ModelBuilder builder)
        {
            builder.Entity<Grade>().HasData(
                new Grade { Id = "grade-1", gradeType = GradeType.Grade8, IsDeleted = false, TenantId = "tenant-1" },
                new Grade { Id = "grade-2", gradeType = GradeType.Grade9, IsDeleted = false, TenantId = "tenant-1" }
            );
        }
    }
}

