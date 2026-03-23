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
        public DataSeederService(DerasaXDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task SeedAllAsync(string baseRootPath)
        {
            var jsonFolderPath = Path.Combine(baseRootPath, "JsonFile");
            
            // Seed Tenants
            await SeedFile<Tenant>(Path.Combine(jsonFolderPath, "tenants.json"), _context.tenants);

            // Seed Security Questions
            await SeedFile<SecurityQuestion>(Path.Combine(jsonFolderPath, "securityQuestions.json"), _context.SecurityQuestions);

            // Seed Grades
            await SeedFile<Grade>(Path.Combine(jsonFolderPath, "grades.json"), _context.grades);

            // Seed Students
            await SeedStudents(Path.Combine(jsonFolderPath, "students.json"));
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

            foreach (var s in students)
            {
                s.EmailConfirmed = true;
                // Password will be 'P@ssword123' by default
                await _userManager.CreateAsync(s, "P@ssword123");
            }
        }
    }
}
