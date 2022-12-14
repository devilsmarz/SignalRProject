using Microsoft.EntityFrameworkCore;
using SignalRBackend.DAL.DBConfiguration.DatabaseConfiguration;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRBackend.DAL.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(DatabaseContext context) : base(context) { }

        public override Task<Message> GetById(Int32 id)
        {
            return Context.Messages.Where(message => message.Id == id).Include(message => message.RepliedMessages).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Message>> GetMessages(Int32 userId, Int32 chatId)
        {
            return await Context.Messages.Where(
                message => message.ChatId == chatId
                && (message.IsDeletedOnlyForCreator == false || (message.UserId != userId))
                && (message.ReceiverId == null || message.ReceiverId == userId || message.UserId == userId))
                .AsNoTracking()
                .Include(message => message.RepliedMessage)
                .ToListAsync();
        }

        public void DeleteById(Int32 id)
        {
            Message message = new Message() { Id = id };
            Context.Messages.Attach(message);
            Context.Messages.Remove(message);
        }

        public void UpdateGraph(Message message)
        {
            foreach (Message item in message.RepliedMessages)
            {
                item.RepliedMessageId = null;
                item.RepliedMessage = null;
                Update(item);
            }
        }
    }
}
