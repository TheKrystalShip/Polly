using Microsoft.Extensions.DependencyInjection;

using TheKrystalShip.Polly.Managers;
using TheKrystalShip.Polly.Services;

namespace TheKrystalShip.Polly.Extensions
{
    /// <summary>
    /// Load necessary types into the service collection
    /// </summary>
    public static class ServiceExtensions
    {
        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            // Add your managers here
            services.AddSingleton<EventManager>();
            services.AddSingleton<ChannelManager>();
            services.AddSingleton<EmbedManager>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Add your services here
            services.AddSingleton<PollService>();

            return services;
        }
    }
}
