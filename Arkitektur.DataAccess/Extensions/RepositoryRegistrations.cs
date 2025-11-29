using Arkitektur.DataAccess.Interceptors;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arkitektur.DataAccess.Extensions
{
    public static class RepositoryRegistrations
    {
        public static void AddRepositoriesExt(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));

                options.AddInterceptors(new AuditDbContextInterceptor());
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
        }
    }
}
