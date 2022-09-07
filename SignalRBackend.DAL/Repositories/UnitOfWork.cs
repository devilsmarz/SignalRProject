﻿using SignalRBackend.DAL.DBConfiguration;
using SignalRBackend.DAL.DBConfiguration.DatabaseConfiguration;
using SignalRBackend.DAL.Interfaces;
using System;

namespace SignalRBackend.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext Context;
        public UnitOfWork(DatabaseContext context)
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