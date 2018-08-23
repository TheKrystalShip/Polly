using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Reflection;
using System.Threading.Tasks;

using TheKrystalShip.Logging;
using TheKrystalShip.Logging.Extensions;
using TheKrystalShip.Polly.Database;
using TheKrystalShip.Polly.Extensions;
using TheKrystalShip.Polly.Managers;
using TheKrystalShip.Polly.Properties;
using TheKrystalShip.Polly.Services;

namespace TheKrystalShip.Polly.Handlers
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commandService;
        private readonly IServiceProvider _services;
        private readonly ILogger<CommandHandler> _logger;

        public CommandHandler(ref DiscordSocketClient client)
        {
            _client = client;

            _commandService = new CommandService(new CommandServiceConfig()
                {
                    LogLevel = LogSeverity.Debug,
                    CaseSensitiveCommands = false,
                    DefaultRunMode = RunMode.Async
                }
            );

            _commandService.AddModulesAsync(Assembly.GetEntryAssembly());

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commandService)
                .AddManagers()
                .AddServices()
                .AddDbContext<SQLiteContext>(x => {
                    x.UseSqlite(Settings.Instance.GetConnectionString("SQLite"));
                })
                .AddLogger()
                .BuildServiceProvider();

            _services.GetRequiredService<EventManager>();
            _logger = _services.GetRequiredService<ILogger<CommandHandler>>();

            _commandService.Log += CommandServiceLog;
            _client.MessageReceived += HandleCommand;
        }

        private Task CommandServiceLog(LogMessage logMessage)
        {
            if (logMessage.Exception is null)
            {
                _logger.LogInformation(logMessage.Message);
            }
            else
            {
                _logger.LogError(logMessage.Exception, logMessage.Message);
            }

            return Task.CompletedTask;
        }

        private async Task HandleCommand(SocketMessage socketMessage)
        {
            SocketUserMessage message = socketMessage as SocketUserMessage;
            if (message is null || message.Author.IsBot)
                return;

            bool inPollChannel = message.Channel.Id == Settings.Instance.GetPollChannel();

            if (!inPollChannel)
                return;

            PollService pollService = _services.GetService<PollService>();
            await pollService.CreatePollAsync(message);
        }
    }
}
