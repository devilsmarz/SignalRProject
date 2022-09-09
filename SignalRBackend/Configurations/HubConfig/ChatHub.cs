using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;

namespace SignalRBackend.WEB.Configurations.HubConfig
{
    public class ChatHub: Hub
    {
        public String GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
