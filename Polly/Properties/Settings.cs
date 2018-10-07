using Microsoft.Extensions.Configuration;

using System.IO;

namespace TheKrystalShip.Polly.Properties
{
    public static class Settings
    {
        private static IConfiguration _config;

        public static IConfiguration Instance => _config ??
            (_config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Properties"))
                .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("secrets.json", optional: false, reloadOnChange: true)
                .Build());
    }
}
