using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

using TheKrystalShip.Polly.Services;

namespace TheKrystalShip.Polly.Modules
{
    public class PollModule : ModuleBase<SocketCommandContext>
    {
        private readonly PollService _pollService;

        public PollModule(PollService pollService)
        {
            _pollService = pollService;
        }

        [Command("poll:")]
        public async Task CreatePollAsync()
        {
            await _pollService.CreatePollAsync(Context.Message);
        }
    }
}
