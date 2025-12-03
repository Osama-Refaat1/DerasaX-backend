using DerasaX.Infrastructure.Extensions;

namespace DerasaX.Api.Helper
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAllServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureServices(configuration);
            return services;
        }
    }
}
