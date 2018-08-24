using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using TheKrystalShip.Polly.Database;
using TheKrystalShip.Polly.Services;

namespace TheKrystalShip.Polly.Modules
{
    [Group("settings")]
    public class SettingsModule : ModuleBase<SocketCommandContext>
    {
        private readonly SettingsService _settingsService;
        private readonly SQLiteContext _dbContext;

        public SettingsModule(SettingsService settingsService, SQLiteContext dbContext)
        {
            _settingsService = settingsService;
            _dbContext = dbContext;
        }

        [Command]
        public async Task DefaultAsync()
        {

        }

        [Command("channel")]
        public async Task GetChannelAsync()
        {

        }

        [Command("channel")]
        public async Task SetChannelAsync(SocketTextChannel channel)
        {

        }
    }
}
