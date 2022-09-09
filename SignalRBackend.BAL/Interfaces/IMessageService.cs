using SignalRBackend.BLL.DTO;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBackend.BLL.Interfaces
{
    public interface IMessageService
    {
        public void Add(MessageDTO message);
        public void Delete(Int32 id, Boolean onlyme);
        public void Update(MessageDTO message);
        public Task<IEnumerable<MessageDTO>> TakeMessages(Int32 page, Int32 userid, Int32 chatid);
        public MessageDTO InsertOrUpdateAndGet(MessageDTO message);
        public Task<IEnumerable<MessageDTO>> GetMessages(Int32 chatid, Int32 userid);
    }
}
