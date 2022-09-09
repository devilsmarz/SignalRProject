using Microsoft.AspNetCore.SignalR;
using SignalRBackend.WEB.Configurations.Interfaces;
using SignalRBackend.WEB.ViewModels;
using System.Threading.Tasks;

namespace SignalRBackend.WEB.Configurations.HubConfig
{
    public class ChatHub: Hub<IChatHub>
    {
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
