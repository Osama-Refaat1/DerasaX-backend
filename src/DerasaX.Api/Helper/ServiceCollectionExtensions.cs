using DerasaX.Application.Extensions;
using DerasaX.Application.Services;
using DerasaX.Application.Services.Abstractions;
using DerasaX.Domain.Entities.Models;
using DerasaX.Infrastructure.DbHelper.Context;
using DerasaX.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;

namespace DerasaX.Api.Helper
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAllServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureServices(configuration);
            services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DerasaXDbContext>()
    .AddDefaultTokenProviders();

            services.AddApplicationServices(configuration);
            return services;
        }
    }
}
