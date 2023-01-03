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
            string connectionString = configuration.GetConnectionString("MySqlConnection");

            services.AddDbContext<IApplicationContextEF, ApplicationContextEF>(options =>
                options.UseMySql(
                    connectionString,
                    new MySqlServerVersion(new Version(8,0,20)),
                    options => options.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: System.TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null)
                ));

            services.AddSingleton<IApplicationContextDapper, ApplicationContextDapper>();

            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            //services.AddScoped<IMessageStatusRepository, MessageStatusRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            //services.AddScoped<IChatParticipantRepository, ChatParticipantRepository>();
            //services.AddScoped<IChatOwnerRepository,ChatOwnerRepository>();
   
            return services;
        }
    }
}
