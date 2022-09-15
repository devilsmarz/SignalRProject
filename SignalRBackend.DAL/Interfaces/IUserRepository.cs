using SignalRBackend.DAL.DomainModels;
using System;

namespace SignalRBackend.DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindByUserName(String username);
    }
}
