using SignalRBackend.DAL.DBConfiguration.DatabaseConfiguration;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace SignalRBackend.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            Chat = new ChatRepository(_context);
            Message = new MessageRepository(_context);
        }

        public IUserRepository User { get; private set; }

        public IChatRepository Chat { get; private set; }

        public IMessageRepository Message { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Int32 Save()
        {
            return _context.SaveChanges();
        }

        public async Task<Int32> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
