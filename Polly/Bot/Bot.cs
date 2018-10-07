using Discord;
using Discord.WebSocket;

using System.Threading.Tasks;

using TheKrystalShip.Polly.Extensions;
using TheKrystalShip.Polly.Handlers;
using TheKrystalShip.Polly.Properties;

namespace TheKrystalShip.Polly
{
    public class Bot
    {
        private static DiscordSocketClient _client;
        private static CommandHandler _commandHandler;
        private static string _token;

        public Bot()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig()
                {
                    LogLevel = LogSeverity.Debug,
                    DefaultRetryMode = RetryMode.AlwaysRetry,
                    ConnectionTimeout = 5000
                }
            );

            _commandHandler = new CommandHandler(ref _client);

            _token = Settings.Instance.GetToken();
        }

        public async Task InitAsync()
        {
            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();
        }
    }
}
