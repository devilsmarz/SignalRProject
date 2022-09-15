using SignalRBackend.DAL.DBConfiguration.DatabaseConfiguration;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Linq;

namespace SignalRBackend.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) { }

        public User FindByUserName(String username)
        {
            return Context.Set<User>().Where(user => user.UserName == username).FirstOrDefault();
        }
    }
}
