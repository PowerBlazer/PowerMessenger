using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PowerMessenger.Core.Contexts;
using PowerMessenger.Core.Repository;
using PowerMessenger.Infrastructure.Contexts;
using PowerMessenger.Infrastructure.Repository;

namespace PowerMessenger.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<IApplicationContextEF, ApplicationContextEF>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IApplicationContextDapper, ApplicationContextDapper>();
            services.AddScoped<IUserRepository, UserRepository>();
   
            return services;
        }
    }
}
