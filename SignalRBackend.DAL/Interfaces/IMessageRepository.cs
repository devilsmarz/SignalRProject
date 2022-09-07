using System;
using System.Collections.Generic;
using System.Text;
using SignalRBackend.DAL.DomainModels;

namespace SignalRBackend.DAL.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
    }
}
