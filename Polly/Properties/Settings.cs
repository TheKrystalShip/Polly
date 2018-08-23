using System.IO;
using Microsoft.Extensions.Configuration;

namespace TheKrystalShip.Polly.Properties
{
    public static class Settings
    {
        private static IConfiguration _config;

        public static IConfiguration Instance => _config ??
            (_config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Properties"))
                .AddJsonFile("settings.json", false, true)
                .Build());
    }
}
