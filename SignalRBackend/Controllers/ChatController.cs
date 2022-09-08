using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRBackend.BLL.DTO;
using SignalRBackend.BLL.Interfaces;
using SignalRBackend.WEB.Configurations.HubConfig;
using SignalRBackend.WEB.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRBackend.WEB.Controllers
{
    [Route("chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hub;
        private readonly IMapper _mapper;
        private readonly IMessageService _messageservice;
        public ChatController(IHubContext<ChatHub> hub, IMapper mapper, IMessageService messageservice)
        {
            _hub = hub;
            _mapper = mapper;
            _messageservice = messageservice;
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(Int32 id)
        {
            var a = _hub.Clients.All.SendAsync("chatData", "messages");
            return Ok(new { Message = "Request Completed}" });
        }

        [Authorize]
        [HttpPost]
        public async Task SendMessage([FromBody]MessageViewModel message)
        {
            //additional business logic 

            _messageservice.Add(_mapper.Map<MessageDTO>(message));
            await _hub.Clients.All.SendAsync("messageReceivedFromApi", message);

            //additional business logic 
        }

        [Authorize]
        [HttpPut]
        public void Put([FromBody] MessageViewModel message)
        {
            _messageservice.Update(_mapper.Map<MessageDTO>(message));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(Int32 id)
        {
            _messageservice.Delete(id);
        }
    }
}
