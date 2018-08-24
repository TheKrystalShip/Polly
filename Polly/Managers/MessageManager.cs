using System.Threading.Tasks;
using Discord;
using TheKrystalShip.Polly.Database;
using TheKrystalShip.Polly.Database.Models;

namespace TheKrystalShip.Polly.Managers
{
    public class MessageManager
    {
        private readonly SQLiteContext _dbContext;

        public MessageManager(SQLiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Message GetMessage(IUserMessage userMessage)
        {
            return GetMessage(userMessage.Id);
        }

        public Message GetMessage(ulong messageId)
        {
            return _dbContext.Messages.Find(messageId.ToString());
        }

        public async Task UpdateMessageAsync(ulong messageId)
        {
            Message message = GetMessage(messageId);

            if (message is null)
                return;

            
        }
    }
}
