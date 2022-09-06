using SignalRBackend.DAL.DBConfiguration;
using SignalRBackend.DAL.Entities;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRBackend.DAL.Services
{
    internal class UserRepository : GenericRepository<User> , IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context) { }
    }
}
