using SignalRBackend.DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRBackend.DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindUserName(String username);
    }
}
