using SignalRBackend.DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRBackend.DAL.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task<IEnumerable<Message>> GetMessages(Int32 userid, Int32 chatid);
        void DeleteById(Int32 id);
        void UpdateGraph(Message message);
    }
}
