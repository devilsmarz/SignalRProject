using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRBackend.BLL.Interfaces;
using SignalRBackend.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRBackend.WEB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IChatService _chatService;
        public ChatController(IMapper mapper, IChatService chatService)
        {
            _mapper = mapper;
            _chatService = chatService;
        }
        [HttpGet("GetAllChats/{userid}")]
        public async Task<IActionResult> GetAllChats(Int32 userid)
        {
            IEnumerable<ChatViewModel> chats = _mapper.Map<IEnumerable<ChatViewModel>>(await _chatService.GetChatsById(userid));
            return Ok(chats);
        }
    }
}
