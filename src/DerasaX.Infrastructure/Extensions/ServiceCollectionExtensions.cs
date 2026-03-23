
using DerasaX.Domain.Interfaces;
using DerasaX.Infrastructure.DbHelper.Context;
using DerasaX.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DerasaX.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextServices(configuration);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
           
            return services;
        }

        private static void AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DerasaXDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("cs")));
        }
    }
}
