﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Reflection;
using System.Threading.Tasks;

using TheKrystalShip.Polly.Extensions;
using TheKrystalShip.Polly.Managers;
using TheKrystalShip.Logging;
using TheKrystalShip.Logging.Extensions;
using TheKrystalShip.Polly.Services;

namespace TheKrystalShip.Polly.Handlers
{
    /// <summary>
    /// In charge of executing incoming commands from the client
    /// </summary>
    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commandService;
        private readonly IConfiguration _config;
        private readonly IServiceProvider _services;
        private readonly ILogger<CommandHandler> _logger;

        public CommandHandler(ref DiscordSocketClient client, ref IConfiguration configuration)
        {
            _client = client;
            _config = configuration;

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
                .AddSingleton(_config)
                .AddManagers()
                .AddServices()
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

            bool inPollChannel = message.Channel.Id == _config.GetPollChannel();

            if (!inPollChannel)
                return;

            PollService pollService = _services.GetService<PollService>();
            await pollService.CreatePollAsync(message);
        }
    }
}
