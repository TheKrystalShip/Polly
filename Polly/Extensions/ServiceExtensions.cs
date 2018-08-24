using Microsoft.Extensions.DependencyInjection;

using TheKrystalShip.Polly.Managers;
using TheKrystalShip.Polly.Services;

namespace TheKrystalShip.Polly.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddSingleton<EventManager>();
            services.AddSingleton<ChannelManager>();
            services.AddSingleton<EmbedManager>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<PollService>();
            services.AddSingleton<AdminService>();
            services.AddSingleton<SettingsService>();

            return services;
        }
    }
}
