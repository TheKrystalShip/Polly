using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using TheKrystalShip.Polly.Services;

namespace TheKrystalShip.Polly.Modules
{
    public class AdminModule : ModuleBase<SocketCommandContext>
    {
        private readonly AdminService _adminService;
        private readonly CommandService _commandService;

        public AdminModule(AdminService adminService, CommandService commandService)
        {
            _adminService = adminService;
            _commandService = commandService;
        }

        [Command("help")]
        public async Task HelpAsync()
        {
            List<CommandInfo> commands = _commandService.Commands.ToList();
            //List<CommandInfo> commands = Context.c
            EmbedBuilder embed = new EmbedBuilder { Color = Color.Purple, Title = "Command list" };

            foreach (var command in commands)
            {
                if (command.Name == "help") continue;
                
                //if (command.Module.Name == typeof(OwnerModule).Name) continue;

                string embedFieldText = command.Summary;

                if (command.Parameters.Count > 0)
                    embedFieldText = command.Parameters.Aggregate(embedFieldText, (current, param) => current + $"\nParameters:\t{param.Type.Name} {param}\t");

                embed.AddField($"{command.Name} ({command.Module.Name.Replace("Module", "")})", embedFieldText);
            }

            await ReplyAsync("", false, embed.Build());
        }
    }
}
