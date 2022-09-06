using SignalRBackend.DAL.DBConfiguration;
using SignalRBackend.DAL.Entities;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRBackend.DAL.Services
{
    internal class MessageRepository : GenericRepository<Message> , IMessageRepository
    {
        public MessageRepository(ApplicationContext context) : base(context) { }
    }
}
