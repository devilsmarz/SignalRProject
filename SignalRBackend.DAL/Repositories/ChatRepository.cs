using SignalRBackend.DAL.DBConfiguration;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.DAL.Interfaces;
using SignalRBackend.DAL.DBConfiguration.DatabaseConfiguration;

namespace SignalRBackend.DAL.Repositories
{
    internal class ChatRepository : GenericRepository<Chat> , IChatRepository
    {
        public ChatRepository(DatabaseContext context) : base(context) { }
    }
}
