using Discord;
using Discord.WebSocket;

using System.Threading.Tasks;

using TheKrystalShip.Logging;

namespace TheKrystalShip.Discord.Bot.Managers
{
    /// <summary>
    /// Hooks into the client events
    /// </summary>
    public class EventManager
    {
        private readonly DiscordSocketClient _client;
        private readonly ILogger<EventManager> _logger;

        public EventManager(DiscordSocketClient client, ILogger<EventManager> logger)
        {
            _client = client;
            _logger = logger;

            _client.Log += ClientLog;
        }

        private Task ClientLog(LogMessage logMessage)
        {
            _logger.LogInformation(logMessage.Message);
            return Task.CompletedTask;
        }
    }
}
