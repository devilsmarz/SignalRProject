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
using Microsoft.AspNetCore.Authorization;
using SignalRBackend.DAL.DomainModels;

namespace SignalRBackend.WEB.Controllers
{
    [Route("[controller]")]
    //[Authorize]
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
        public async Task<IActionResult> AddOrUpdateMessage([FromBody] MessageViewModel message)
        {
            if (await _messageservice.IsUserInChat(message.UserId, message.ChatId))
            {
                MessageViewModel messageFromDb = _mapper.Map<MessageViewModel>(_messageservice.AddOrUpdateMessage(_mapper.Map<MessageDTO>(message)));
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, ContractResolver = new CamelCasePropertyNamesContractResolver() };
                await _hub.Clients.Group(message.ChatId.ToString()).SendAsync("ReceiveMessage", JsonConvert.SerializeObject(messageFromDb, jsonSerializerSettings));
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{messageId}/{userId}/{chatId}/{isDeletedOnlyForCreator}")]
        public async Task<IActionResult> DeleteMessagee(Int32 messageId, Int32 userId, Int32 chatId, Boolean isDeletedOnlyForCreator)
        {
            if (await _messageservice.IsUserInChat(userId, chatId))
            {
                await _messageservice.DeleteMessage(messageId, isDeletedOnlyForCreator);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{userid}/{chatid}/{page?}")]
        public async Task<IActionResult> TakeMessages(Int32 userId, Int32 chatId, Int32? page = null)
        {
            if (await _messageservice.IsUserInChat(userId, chatId))
            {
                PageInfoViewModel chatinfo = _mapper.Map<PageInfoViewModel>(await _messageservice.TakeMessages(page, userId, chatId));
                return Ok(chatinfo);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
