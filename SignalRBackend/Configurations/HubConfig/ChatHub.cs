using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalRBackend.WEB.Configurations.HubConfig
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ChatHub : Hub
    {
        public String GetConnectionId()
        {
            return Context.ConnectionId;
        }

        public Task JoinRoom(String chatId)
        {
            GetConnectionId();
            return Groups.AddToGroupAsync(Context.ConnectionId, chatId);
        }

        public Task LeaveRoom(String chatId)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
        }
    }
}
