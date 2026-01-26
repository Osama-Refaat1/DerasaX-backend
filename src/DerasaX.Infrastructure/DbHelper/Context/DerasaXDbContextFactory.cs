using DerasaX.Application.Services.Abstractions;
using DerasaX.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Infrastructure.DbHelper.Context
{
    public class DerasaXDbContextFactory : IDesignTimeDbContextFactory<DerasaXDbContext>
    {
        public DerasaXDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DerasaXDbContext>();
            optionsBuilder.UseNpgsql("Host=ep-summer-moon-ahxdjit9-pooler.c-3.us-east-1.aws.neon.tech;Port=5432; Database=neondb; Username=neondb_owner; Password=npg_4jps2JucaCHD; SSL Mode=Require; Trust Server Certificate=true ");

            var tenantService = new DummyTenantService();

            return new DerasaXDbContext(optionsBuilder.Options, tenantService);
        }
        public class DummyTenantService : ITenantService
        {
            public Tenant? GetCurrentTenant() => new Tenant { Id = "DefaultTenantId" };
            public string? GetConnectionString() => "Host=ep-summer-moon-ahxdjit9-pooler.c-3.us-east-1.aws.neon.tech;Port=5432; Database=neondb; Username=neondb_owner; Password=npg_4jps2JucaCHD; SSL Mode=Require; Trust Server Certificate=true ";
            public string? GetDatabaseProvider() => "PostgreSQL";
        }
    }
}
