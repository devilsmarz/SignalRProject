using System;
using System.Collections.Generic;
using System.Text;
using SignalRBackend.DAL.DomainModels;

namespace SignalRBackend.DAL.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        public Message UpdateAndGet(Message message);
        public IEnumerable<Message> FilterAndGet(Int32 chatid, Int32 userid);
    }
}
