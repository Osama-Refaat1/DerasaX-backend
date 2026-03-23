using DerasaX.Application.Extensions;
using DerasaX.Application.Services;
using DerasaX.Application.Services.Abstractions;
using DerasaX.Application.Services.Abstractions.Notification;
using DerasaX.Application.Services.Notification;
using DerasaX.Api.Realtime;
using DerasaX.Domain.Entities.Models;
using DerasaX.Infrastructure.DbHelper.Context;
using DerasaX.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using DerasaX.Api.SeedData;


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
            services.AddScoped<IRealtimeSender, SignalRSender>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddSignalR();
            services.AddScoped<DataSeederService>();


            return services;
        }
    }
}
