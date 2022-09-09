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

        [HttpGet("{chatid}/{userid}")]
        public async Task<IActionResult> GetMessages(Int32 chatid, Int32 userid)
        {
            IEnumerable<MessageViewModel> messagearray = _mapper.Map<IEnumerable<MessageViewModel>>(await _messageservice.GetMessages(chatid, userid));

            return Ok(messagearray);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] MessageViewModel message)
        {
            _messageservice.Add(_mapper.Map<MessageDTO>(message));
            MessageViewModel messageFromDb = _mapper.Map<MessageViewModel>(_messageservice.InsertOrUpdateAndGet(_mapper.Map<MessageDTO>(message)));
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, ContractResolver = new CamelCasePropertyNamesContractResolver()};
            await _hub.Clients.Group(message.ChatId.ToString()).SendAsync("ReceiveMessage", JsonConvert.SerializeObject(messageFromDb, jsonSerializerSettings));
           // await _hub.Clients.Group(message.ChatId.ToString()).SendAsync("ReceiveMessage", messageFromDb);
            return Ok();
        }

        [HttpPut]
        public void UpdateMessage([FromBody] MessageViewModel message)
        {
            _messageservice.Update(_mapper.Map<MessageDTO>(message));
        }

        [HttpDelete("{id}")]
        public void Delete(Int32 id)
        {
            _messageservice.Delete(id);
        }
    }
}
