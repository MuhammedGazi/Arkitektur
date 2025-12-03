using Amazon.Runtime;
using Amazon.S3;
using Arkitektur.Business.Services.AboutServices;
using Arkitektur.Business.Services.AppointmentServices;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Threading.Tasks;

namespace Arkitektur.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static async Task<IServiceCollection> AddServicesExt(this IServiceCollection services,IConfiguration configuration)
        {
            services.Scan(opt => 
                          opt.FromAssemblyOf<BusinessAssembly>()
                          .AddClasses(x => x.Where(t => t.Name.EndsWith("Service")))
                          .AsImplementedInterfaces()
                          .WithScopedLifetime());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            var awsOptions = configuration.GetAWSOptions();
            awsOptions.Region = Amazon.RegionEndpoint.EUNorth1;
            awsOptions.Credentials = new BasicAWSCredentials(
                configuration["AWS:AccessKey"],
                configuration["AWS:SecretKey"]);
            services.AddDefaultAWSOptions(awsOptions);
            services.AddAWSService<IAmazonS3>();


            return services;
        }
    }
}
