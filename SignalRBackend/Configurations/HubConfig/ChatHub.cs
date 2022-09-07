using Microsoft.AspNetCore.SignalR;
using SignalRBackend.WEB.Configurations.Interfaces;
using SignalRBackend.WEB.ViewModels;
using System.Threading.Tasks;

namespace SignalRBackend.WEB.Configurations.HubConfig
{
    public class ChatHub: Hub<IChatHub>
    {
        public async Task BroadcastAsync(MessageViewModel message)
        {
            await Clients.All.MessageReceivedFromHub(message);
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.All.NewUserConnected("a new user connectd");
        }
    }
}
