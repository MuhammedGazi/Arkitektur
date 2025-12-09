using Amazon.Runtime;
using Amazon.S3;
using Arkitektur.Business.Options;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Arkitektur.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static async Task<IServiceCollection> AddServicesExt(this IServiceCollection services, IConfiguration configuration)
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

            var tokenOptions = configuration.GetSection(nameof(JwtTokenOptions)).Get<JwtTokenOptions>();
            services.Configure<JwtTokenOptions>(configuration.GetSection(nameof(JwtTokenOptions)));
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audince,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.Key)),
                    ClockSkew = TimeSpan.Zero
                };
            });


            return services;
        }
    }
}
