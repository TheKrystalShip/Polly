using System.Threading.Tasks;
using Discord.Commands;
using TheKrystalShip.Polly.Services;

namespace TheKrystalShip.Polly.Modules
{
    public class AdminModule : ModuleBase<SocketCommandContext>
    {
        private readonly AdminService _adminService;

        public AdminModule(AdminService adminService)
        {
            _adminService = adminService;
        }

        [Command("help")]
        public async Task HelpAsync()
        {

        }
    }
}
