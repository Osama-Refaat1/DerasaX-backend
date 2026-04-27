using DerasaX.Domain.Entities.Models;
using DerasaX.Infrastructure.DbHelper.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DerasaX.Api.SeedData
{
    public class DataSeederService
    {
        private readonly DerasaXDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DataSeederService(DerasaXDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task SeedAllAsync(string baseRootPath)
        {
            await SeedRoles();
            var jsonFolderPath = Path.Combine(baseRootPath, "JsonFile");
            
            // Seed Tenants
            await SeedFile<Tenant>(Path.Combine(jsonFolderPath, "tenants.json"), _context.tenants);

            await SeedAdmin();
            await SeedTeachers();

            // Seed Grades
            await SeedFile<Grade>(Path.Combine(jsonFolderPath, "grades.json"), _context.grades);

            // Seed Students
            await SeedStudents(Path.Combine(jsonFolderPath, "students.json"));
        }
        private async Task SeedRoles()
        {
            string[] roles = { "SchoolAdmin", "Teacher", "Student" };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private async Task SeedFile<T>(string path, DbSet<T> dbSet) where T : class
        {
            if (await dbSet.AnyAsync()) return;
            var data = await File.ReadAllTextAsync(path);
            var items = JsonSerializer.Deserialize<List<T>>(data);
            if (items != null)
            {
                await dbSet.AddRangeAsync(items);
                await _context.SaveChangesAsync();
            }
        }
       
        private async Task SeedStudents(string path)
        {
            if (await _context.students.AnyAsync()) return;

            var data = await File.ReadAllTextAsync(path);

            var students = JsonSerializer.Deserialize<List<Student>>(data);

            if (students == null) return;

            foreach (var s in students)
            {
                

                // 1- Create Identity User
                var result = await _userManager.CreateAsync(s, "P@ssword123");

                if (!result.Succeeded)
                    continue;

                // 2- Assign Role
                await _userManager.AddToRoleAsync(s, "Student");

                // 3- TPT mapping
                _context.students.Add(new Student
                {
                    Id = s.Id
                });
            }

            await _context.SaveChangesAsync();
        }
        private async Task SeedAdmin()
        {
            if (await _context.SchoolAdmin.AnyAsync()) return;

            var admin = new ApplicationUser
            {
                UserName = "admin",
                FullName = "System Admin",
                LoginCode = "27102004",
                Gender =(Domain.Enums.Gender?)1,
                TenantId = "tenant-1"

            };

            var result = await _userManager.CreateAsync(admin, "Admin@123");

            if (!result.Succeeded)
                return;

            await _userManager.AddToRoleAsync(admin, "SchoolAdmin");

            _context.SchoolAdmin.Add(new SchoolAdmin
            {
                Id = admin.Id
            });

            await _context.SaveChangesAsync();
        }
        //private async Task SeedTeachers()
        //{
        //    if (await _context.teachers.AnyAsync()) return;

        //    var teacher = new ApplicationUser
        //    {
        //        UserName = "teacher1",
        //        FullName = "Ahmed",
        //        LoginCode = "TEACH001",
        //        TenantId = "tenant-1",
        //        Gender =(Domain.Enums.Gender?)1,
        //    };

        //    var result = await _userManager.CreateAsync(teacher, "Teacher@123");

        //    if (!result.Succeeded)
        //        return;

        //    await _userManager.AddToRoleAsync(teacher, "teachers");

        //    _context.teachers.Add(new Teacher
        //    {
        //        Id = teacher.Id
        //    });

        //    await _context.SaveChangesAsync();
        //}
        private async Task SeedTeachers()
        {
            var userName = "malak";

            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                var teacher = new Teacher
                {
                    UserName = userName,
                    FullName = "Malak",
                    LoginCode = "TEACH002",
                    TenantId = "tenant-1",
                    Gender = (Domain.Enums.Gender?)2,
                };

                var result = await _userManager.CreateAsync(teacher, "MMmm2004@");

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(",", result.Errors.Select(e => e.Description)));
                }

                await _userManager.AddToRoleAsync(teacher, "Teacher");
            }
        }

    }
}
