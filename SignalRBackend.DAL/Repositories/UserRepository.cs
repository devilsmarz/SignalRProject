using SignalRBackend.DAL.DBConfiguration;
using SignalRBackend.DAL.DBConfiguration.DatabaseConfiguration;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignalRBackend.DAL.Repositories
{
    internal class UserRepository : GenericRepository<User> , IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) { }

        public User FindByUserName(String username)
        {
            return Context.Set<User>().Where(user => user.UserName == username).FirstOrDefault();
        }
    }
}
