using Microsoft.Extensions.Configuration;

namespace TheKrystalShip.Polly.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetName(this IConfiguration config)
        {
            return config.GetSection("Bot")["Name"];
        }

        public static string GetToken(this IConfiguration config)
        {
            return config.GetSection("Bot")["Token"];
        }

        public static string GetPrefix(this IConfiguration config)
        {
            return config.GetSection("Bot")["Prefix"];
        }

        public static ulong GetPollChannel(this IConfiguration config)
        {
            return ulong.Parse(config.GetSection("Bot")["PollChannel"]);
        }
    }
}
