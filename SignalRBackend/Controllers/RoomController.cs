using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRBackend.BLL.DTO;
using SignalRBackend.BLL.Interfaces;
using SignalRBackend.WEB.Configurations.HubConfig;
using SignalRBackend.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRBackend.WEB.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hub;

        public RoomController(IHubContext<ChatHub> hub, IMapper mapper, IMessageService messageservice)
        {
            _hub = hub;
        }

        [HttpPost("Join/{connectionId}/{chatName}")]
        public async Task<IActionResult> JoinChat(String connectionId, string ChatName)
        {
            await _hub.Groups.AddToGroupAsync(connectionId, ChatName);
            return Ok();
        }
    }
}
