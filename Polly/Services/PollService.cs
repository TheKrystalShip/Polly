using System.Collections.Generic;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace TheKrystalShip.Polly.Services
{
    public class PollService
    {
        private readonly List<Emoji> _reactions;

        public PollService()
        {
            _reactions = new List<Emoji>();
            _reactions.Add(new Emoji("👎🏻"));
            _reactions.Add(new Emoji("👍🏻"));
            _reactions.Add(new Emoji("🤷"));
        }
        
        public async Task AddReactionsAsync(SocketUserMessage message)
        {
            foreach (Emoji reaction in _reactions)
            {
                await message.AddReactionAsync(reaction);
            }
        }
    }
}
