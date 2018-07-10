using TheKrystalShip.Logging;

namespace TheKrystalShip.Discord.Bot.Services
{
    public class GreetingService
    {
        private readonly ILogger<GreetingService> _logger;

        public GreetingService(ILogger<GreetingService> logger)
        {
            _logger = logger;
        }
    }
}
