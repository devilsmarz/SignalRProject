using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SignalRBackend.DAL.DomainModels;

namespace SignalRBackend.DAL.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        public Message InsertOrUpdateAndGet(Message message);
        public Task<IEnumerable<Message>> GetMessages(Int32 chatid, Int32 userid);
        public Task<IEnumerable<Message>> UploadUpper(Int32 id);
    }
}
