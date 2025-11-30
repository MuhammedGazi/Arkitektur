using Arkitektur.Business.Services.AboutServices;
using Microsoft.Extensions.DependencyInjection;

namespace Arkitektur.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddServicesExt(this IServiceCollection services)
        {
            services.AddScoped<IAboutService,AboutService>();

            return services;
        }
    }
}
