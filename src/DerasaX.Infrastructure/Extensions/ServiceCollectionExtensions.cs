using DerasaX.Domain.Settings;
using DerasaX.Infrastructure.DbHelper.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContextServices(configuration);
         
            return services;
        }

        private static void AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            TenantSettings options = new();
            configuration.GetSection(nameof(TenantSettings)).Bind(options);
            var defaultDbProvider = options.Defaults.DBProvider;
            if (defaultDbProvider.ToLower() =="PostgreSQL")
            {
                services.AddDbContext<DerasaXDbContext>(m => m.UseNpgsql());
            }
            foreach (var tenant in options.Tenants)
            {
                var connectionString = tenant.ConnectionString??options.Defaults.ConnectionString;
                using var scope = services.BuildServiceProvider().CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<DerasaXDbContext>();
                dbContext.Database.SetConnectionString(connectionString);
                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    dbContext.Database.Migrate();
                }
            }
        }
        //private static void AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        //{
        //    // جلب الـ TenantSettings من IConfiguration
        //    var tenantSettings = configuration.GetSection(nameof(TenantSettings)).Get<TenantSettings>();

        //    // جلب connection string الافتراضي
        //    var defaultConnectionString = tenantSettings.Defaults.ConnectionString;

        //    // تسجيل DbContext بشكل صحيح
        //    services.AddDbContext<DerasaXDbContext>(options =>
        //    {
        //        options.UseNpgsql(defaultConnectionString);
        //    });
        //}

        // **مهم:** إزالة أي BuildServiceProvider أو Migrate هنا
        // الميجريشن هيشتغل 


        //private static void AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var tenantSettings = new TenantSettings();
        //    configuration.GetSection(nameof(TenantSettings)).Bind(tenantSettings);

        //    services.AddDbContext<DerasaXDbContext>(options =>
        //    {
        //        var connectionString = tenantSettings.Defaults.ConnectionString;
        //        options.UseNpgsql(connectionString);
        //    });
        //}
        //private static void AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var connectionString = configuration.GetConnectionString("cs");
        //    services.AddDbContext<DerasaXDbContext>(options =>
        //    {
        //        options.UseNpgsql(connectionString);
        //    });

        //}
    }
    }
