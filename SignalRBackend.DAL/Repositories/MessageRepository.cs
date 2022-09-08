using SignalRBackend.DAL.DBConfiguration;
using SignalRBackend.DAL.DBConfiguration.DatabaseConfiguration;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignalRBackend.DAL.Repositories
{
    internal class MessageRepository : GenericRepository<Message> , IMessageRepository
    {
        public MessageRepository(DatabaseContext context) : base(context) { }
        public Message UpdateAndGet(Message message)
        {
            return Context.Set<Message>().Update(message).Entity;
        }
        public IEnumerable<Message> FilterAndGet(Int32 chatid, Int32 userid)
        {
            IEnumerable<Message> messages = Context.Messages.Where(s => s.ChatId == chatid && s.UserId == userid);
            return messages;
        }
    }
}
