using SignalRBackend.DAL.DBConfiguration;
using SignalRBackend.DAL.Interfaces;
using System;

namespace SignalRBackend.DAL.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext Context;
        public UnitOfWork(ApplicationContext context)
        {
            Context = context;
            User = new UserRepository(Context);
            Chat = new ChatRepository(Context);
            Message = new MessageRepository(Context);
        }

        public IUserRepository User
        {
            get;
            private set;
        }

        public IChatRepository Chat
        {
            get;
            private set;
        }

        public IMessageRepository Message
        {
            get;
            private set;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public Int32 Save()
        {
            return Context.SaveChanges();
        }
    }
}
