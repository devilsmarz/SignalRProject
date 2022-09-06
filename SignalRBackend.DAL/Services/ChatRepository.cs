using SignalRBackend.DAL.DBConfiguration;
using SignalRBackend.DAL.Entities;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRBackend.DAL.Services
{
    internal class ChatRepository : GenericRepository<Chat> , IChatRepository
    {
        public ChatRepository(ApplicationContext context) : base(context) { }
    }
}
