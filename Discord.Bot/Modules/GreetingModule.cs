using Discord.Commands;

using System.Threading.Tasks;

using TheKrystalShip.Logging;

namespace TheKrystalShip.Discord.Bot.Modules
{
    public class GreetingModule : ModuleBase<SocketCommandContext>
    {
        private readonly ILogger<GreetingModule> _logger;
        
        public GreetingModule(ILogger<GreetingModule> logger)
        {
            _logger = logger;
        }

        [Command("hello")]
        [Alias("hello there", "hey")]
        [Summary("Replies with a custom message")]
        public async Task GreetAsync()
        {
            await ReplyAsync($"General {Context.User.Username} ⚔️⚔️");
        }
    }
}
