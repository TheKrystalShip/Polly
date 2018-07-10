using Microsoft.Extensions.DependencyInjection;

using TheKrystalShip.Discord.Bot.Managers;
using TheKrystalShip.Discord.Bot.Services;

namespace TheKrystalShip.Discord.Bot.Extensions
{
    /// <summary>
    /// Load necessary types into the service collection
    /// </summary>
    public static class ServiceExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            // Add your handlers here

            return services;
        }

        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            // Add your managers here
            services.AddSingleton<EventManager>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Add your services here
            services.AddSingleton<GreetingService>();

            return services;
        }
    }
}
