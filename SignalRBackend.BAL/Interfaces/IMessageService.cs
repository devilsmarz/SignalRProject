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
        public void Delete(Int32 id);
        public void Update(MessageDTO message);
        public MessageDTO InsertOrUpdateAndGet(MessageDTO message);
        public void GetAll(Int32 chatid, Int32 userid);
        public Task<IEnumerable<MessageDTO>> GetMessages(Int32 chatid, Int32 userid);
    }
}
