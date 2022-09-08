using SignalRBackend.BLL.DTO;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRBackend.BLL.Interfaces
{
    public interface IMessageService
    {
        public void Add(MessageDTO message);
        public void Delete(Int32 id);
        public void Update(MessageDTO message);
        public MessageDTO UpdateAndGet(MessageDTO message);
        public void GetAll(Int32 chatid, Int32 userid);
        public IEnumerable<MessageDTO> FilterAndGet(Int32 chatid, Int32 userid);
    }
}
