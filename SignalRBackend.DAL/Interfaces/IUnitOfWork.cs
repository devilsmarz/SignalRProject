using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRBackend.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User
        {
            get;
        }
        IChatRepository Chat
        {
            get;
        }
        IMessageRepository Message
        {
            get;
        }
        Int32 Save();
    }
}
