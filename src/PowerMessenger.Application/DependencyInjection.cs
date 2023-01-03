using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PowerMessenger.Application.Services;
using PowerMessenger.Core.Services;

namespace PowerMessenger.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesApplication(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddSingleton<IJwtToken, JwtToken>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IMessageService, MessageService>();

            return services;
        }
    }
}
