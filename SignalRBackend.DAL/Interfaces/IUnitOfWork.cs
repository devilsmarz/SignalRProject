using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        Task<Int32> SaveAsync();
    }
}
