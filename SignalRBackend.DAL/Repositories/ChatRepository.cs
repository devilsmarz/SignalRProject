﻿using SignalRBackend.DAL.DBConfiguration;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.DAL.Interfaces;
using SignalRBackend.DAL.DBConfiguration.DatabaseConfiguration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SignalRBackend.DAL.Repositories
{
    internal class ChatRepository : GenericRepository<Chat> , IChatRepository
    {
        public ChatRepository(DatabaseContext context) : base(context) { }
        public async override Task<Chat> GetById(Int32 id)
        {
            return await Context.Chats.Where(chat => chat.Id == id).Include(chat => chat.Users).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Chat>> GetChatsById(Int32 userId)
        {
            IEnumerable<Chat> chats = await Context.Set<Chat>().Where(chat => chat.Users.Any(user => user.Id == userId)).Include(chat => chat.Users).AsNoTracking().ToListAsync();
            return chats;
        }
    }
}
