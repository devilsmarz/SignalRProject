using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalRBackend.WEB.Configurations.HubConfig
{
    public class ChatHub: Hub
    {
        public String GetConnectionId()
        {
            return Context.ConnectionId;
        }

        public Task JoinRoom(String chatId)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, chatId);
        }
    }
}
