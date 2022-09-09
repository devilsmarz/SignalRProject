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
        public Message InsertOrUpdateAndGet(Message message)
        {
            Message messageDB = Context.Set<Message>().Update(message).Entity;
            var messages = Context.Set<Message>().Include(message => message.User).Include(message => message.Chat).ToList();
            return messageDB;
        }
        public async Task<IEnumerable<Message>> GetMessages(Int32 chatid, Int32 userid)
        {
            IEnumerable<Message> messages = await Context.Messages.Where(s => s.ChatId == chatid && s.UserId == userid).ToListAsync();
            return messages;
        }
        public async Task<ChatInfo> TakeMessages(Int32 page, Int32 userid, Int32 chatid)
        {
            ChatInfo chatinfo = new ChatInfo();
            chatinfo.CurrentPageNumber = page;
            chatinfo.MessagesOnPage = Context.Messages
                .Where(s => s.ChatId == chatid && (s.IsDeletedForMe == false || (s.UserId != userid)))
                .Skip(page - 1 * 20)
                .Take(20);
            
            Context.Messages.Where(s => s.ChatId == chatid && s.UserId == userid).Count()) % 20 == 0 ?
            chatinfo.TotalPages = Convert.ToInt32(
                Math.Ceiling(
                    Convert.ToDouble(
                        Context.Messages
                        .Where(s => s.ChatId == chatid && s.UserId == userid)
                        .Count())/20));
            return chatinfo;
        }
    }
}
