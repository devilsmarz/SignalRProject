using SignalRBackend.WEB.ViewModels;
using System;
using System.Threading.Tasks;

namespace SignalRBackend.WEB.Configurations.Interfaces
{
        public interface IChatHub
        {
            Task MessageReceivedFromHub(MessageViewModel message);

            Task NewUserConnected(String message);
        }
}
