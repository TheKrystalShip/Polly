using Discord;
using Discord.WebSocket;

namespace TheKrystalShip.Polly.Managers
{
    public class EmbedManager
    {
        public EmbedManager()
        {

        }

        public Embed CreatePollEmbed(IUserMessage message)
        {
            Embed embed = new EmbedBuilder()
                .WithAuthor(message.Author)
                .WithColor(Color.Gold)
                .WithCurrentTimestamp()
                .WithTitle(message.Content)
                .Build();

            return embed;
        }
    }
}
