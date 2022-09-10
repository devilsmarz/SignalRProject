using Microsoft.EntityFrameworkCore;
using SignalRBackend.DAL.DBConfiguration;
using SignalRBackend.DAL.DBConfiguration.DatabaseConfiguration;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBackend.DAL.Repositories
{
    internal class MessageRepository : GenericRepository<Message> , IMessageRepository
    {
        public MessageRepository(DatabaseContext context) : base(context) { }

        public override Message GetById(Int32 id)
        {
            return Context.Messages.Where(message => message.Id == id).Include(message => message.User).Include(message => message.Chat).FirstOrDefault();
        }

        public async Task<IEnumerable<Message>> TakeMessages(Int32 userid, Int32 chatid)
        {
            return await Context.Messages.Where(s => s.ChatId == chatid && (s.IsDeletedOnlyForCreator == false || (s.UserId != userid))).ToListAsync();
        }

        public void DeleteById(Int32 id)
        {
            Message message = new Message() { Id = id };
            Context.Messages.Attach(message);
            Context.Messages.Remove(message);           
        }
    }
}
