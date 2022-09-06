using System;
using System.Collections.Generic;
using System.Text;
using SignalRBackend.DAL.Entities;

namespace SignalRBackend.DAL.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
    }
}
