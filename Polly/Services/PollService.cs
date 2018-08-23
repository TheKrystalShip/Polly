using Discord;
using Discord.Rest;
using Discord.WebSocket;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TheKrystalShip.Polly.Managers;

namespace TheKrystalShip.Polly.Services
{
    public class PollService
    {
        private readonly List<IEmote> _reactions;
        private readonly ChannelManager _channelManager;
        private readonly EmbedManager _embedManager;

        public PollService(ChannelManager channelManager, EmbedManager embedManager)
        {
            _reactions = new List<IEmote>();
            _reactions.Add(new Emoji("👍🏻"));
            _reactions.Add(new Emoji("👎🏻"));
            _reactions.Add(new Emoji("🤷"));

            _channelManager = channelManager;
            _embedManager = embedManager;
        }

        public async Task CreatePollAsync(IUserMessage message)
        {
            ITextChannel originChannel = message.Channel as ITextChannel;

            if (originChannel is null)
                return;

            await _channelManager.DeleteMessagesAsync(originChannel, amount: 1);
            Embed embed = _embedManager.CreatePollEmbed(message);

            IUserMessage pollMessage = await originChannel.SendMessageAsync(String.Empty, false, embed);
            await AddReactionsAsync(pollMessage);
        }

        public async Task AddReactionsAsync(IUserMessage message)
        {
            foreach (Emoji reaction in _reactions)
            {
                await message.AddReactionAsync(reaction);
            }
        }
    }
}
