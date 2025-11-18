using Microsoft.Extensions.DependencyInjection;
using RegalLogoIntegration.Repositories.Interfaces;
using RegalLogoIntegration.Repositories;
using RegalLogoIntegration.Services.Interfaces;
using RegalLogoIntegration.Services;

namespace RegalLogoIntegration.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddProjectServices(this IServiceCollection services)
        {
            // Repository
            services.AddScoped<ICLCARDRepository, CLCARDRepository>();

            // Service
            services.AddScoped<ICLCARDService, CLCARDService>();

        }
    }
}
