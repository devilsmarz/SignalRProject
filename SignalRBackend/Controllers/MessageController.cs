using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRBackend.BLL.DTO;
using SignalRBackend.BLL.Interfaces;
using SignalRBackend.WEB.Configurations.HubConfig;
using SignalRBackend.WEB.Shared.Functions;
using SignalRBackend.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRBackend.WEB.Controllers
{
    [Route("[controller]")]
    [Authorize]
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

        [HttpPut]
        public async Task<IActionResult> UpdateMessage([FromBody] MessageViewModel message)
        {
            if (await _messageservice.IsUserInChat(message.UserId, message.ChatId))
            {
                MessageViewModel messageDb = _mapper.Map<MessageViewModel>(_messageservice.AddOrUpdateMessage(_mapper.Map<MessageDTO>(message)));

                if (message.ReceiverId == null)
                {
                    await _hub.Clients.Group(message.ChatId.ToString()).SendAsync("ReceiveUpdatedMessage", JsonFunction.SerializeObject(messageDb));
                }
                else
                {
                    await _hub.Clients.Users(new List<String>() { message.UserId.ToString(), message.ReceiverId.ToString() }).SendAsync("ReceiveUpdatedMessage", JsonFunction.SerializeObject(messageDb));
                }

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] MessageViewModel message)
        {
            if (await _messageservice.IsUserInChat(message.UserId, message.ChatId))
            {
                MessageViewModel messageDb = _mapper.Map<MessageViewModel>(_messageservice.AddOrUpdateMessage(_mapper.Map<MessageDTO>(message)));

                if (message.ReceiverId == null)
                {
                    await _hub.Clients.Group(message.ChatId.ToString()).SendAsync("ReceiveNewMessage", JsonFunction.SerializeObject(messageDb));
                }
                else
                {
                    await _hub.Clients.Users(new List<String>() { message.UserId.ToString(), message.ReceiverId.ToString() }).SendAsync("ReceiveNewMessage", JsonFunction.SerializeObject(messageDb));
                }
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{messageId}/{userId}/{chatId}/{isDeletedOnlyForCreator}")]
        public async Task<IActionResult> DeleteMessage(Int32 messageId, Int32 userId, Int32 chatId, Boolean isDeletedOnlyForCreator)
        {
            if (await _messageservice.IsUserInChat(userId, chatId))
            {
                await _messageservice.DeleteMessage(messageId, isDeletedOnlyForCreator);
                if (!isDeletedOnlyForCreator)
                {
                    await _hub.Clients.Group(chatId.ToString()).SendAsync("DeleteMessage");
                }
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
