using Discord;
using Discord.WebSocket;

using Microsoft.Extensions.Configuration;

using System;
using System.IO;
using System.Threading.Tasks;

using TheKrystalShip.Polly.Extensions;
using TheKrystalShip.Polly.Handlers;

namespace TheKrystalShip.Polly
{
    public class Program
    {
        private static IConfiguration _config;
        private static DiscordSocketClient _client;
        private static CommandHandler _commandHandler;
        private static string _token;

        public static async Task Main(string[] args)
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Properties"))
                .AddJsonFile("settings.json", false, true)
                .Build();

            Console.Title = _config.GetName();

            _token = _config.GetToken();

            _client = new DiscordSocketClient(new DiscordSocketConfig()
                {
                    LogLevel = LogSeverity.Debug,
                    DefaultRetryMode = RetryMode.AlwaysRetry,
                    ConnectionTimeout = 5000
                }
            );

            _commandHandler = new CommandHandler(ref _client, ref _config);

            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();
            await Task.Delay(-1);
        }
    }
}
