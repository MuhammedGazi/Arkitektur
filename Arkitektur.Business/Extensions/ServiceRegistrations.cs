using Arkitektur.Business.Services.AboutServices;
using Arkitektur.Business.Services.AppointmentServices;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Arkitektur.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddServicesExt(this IServiceCollection services)
        {
            services.Scan(opt => 
                          opt.FromAssemblyOf<BusinessAssembly>()
                          .AddClasses(x => x.Where(t => t.Name.EndsWith("Service")))
                          .AsImplementedInterfaces()
                          .WithScopedLifetime());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
