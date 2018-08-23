using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Threading.Tasks;

using TheKrystalShip.Logging;

namespace TheKrystalShip.Polly.Managers
{
    public class ChannelManager
    {
        private readonly ILogger<ChannelManager> _logger;

        public ChannelManager(ILogger<ChannelManager> logger)
        {
            _logger = logger;
        }

        public async Task DeleteMessagesAsync(ITextChannel channel, int amount = 1)
        {
            IEnumerable<IMessage> messages = await channel.GetMessagesAsync(limit: amount).Flatten();
        }
    }
}
