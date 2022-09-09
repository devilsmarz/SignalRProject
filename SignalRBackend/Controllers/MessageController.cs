using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRBackend.BLL.DTO;
using SignalRBackend.BLL.Interfaces;
using SignalRBackend.WEB.Configurations.HubConfig;
using SignalRBackend.WEB.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.Text.Json;
using Newtonsoft.Json.Serialization;

namespace SignalRBackend.WEB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hub;
        private readonly IMapper _mapper;
        private readonly IMessageService _messageservice;
        public MessageController(IHubContext<ChatHub> hub, IMapper mapper, IMessageService messageservice)
        {
            _hub = hub;
            _mapper = mapper;
            _messageservice = messageservice;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] MessageViewModel message)
        {
            MessageViewModel messageFromDb = _mapper.Map<MessageViewModel>(_messageservice.AddMessage(_mapper.Map<MessageDTO>(message)));
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, ContractResolver = new CamelCasePropertyNamesContractResolver()};
            await _hub.Clients.Group(message.ChatId.ToString()).SendAsync("ReceiveMessage", JsonConvert.SerializeObject(messageFromDb, jsonSerializerSettings));
            return Ok();
        }

        [HttpPut]
        public void UpdateMessage([FromBody] MessageViewModel message)
        {
            _messageservice.UpdateMessage(_mapper.Map<MessageDTO>(message));
        }

        [HttpDelete]
        public void Delete([FromBody] MessageViewModel message)
        {
            _messageservice.DeleteMessage(_mapper.Map<MessageDTO>(message));
        }

        [HttpGet("{userid}/{chatid}/{page}")]
        public async Task<IActionResult> TakeMessages(Int32 userid, Int32 chatid, Int32? page = null)
        {
            PageInfoViewModel chatinfo = _mapper.Map<PageInfoViewModel>(await _messageservice.TakeMessages(page, userid, chatid));
            return Ok(chatinfo);
        }
    }
}
