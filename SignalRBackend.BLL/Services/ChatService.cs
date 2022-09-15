using AutoMapper;
using SignalRBackend.BLL.DTO;
using SignalRBackend.BLL.Interfaces;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRBackend.BLL.Services
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ChatService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ChatDTO>> GetChatsById(Int32 userId)
        {
            IEnumerable<ChatDTO> chats = _mapper.Map<IEnumerable<ChatDTO>>(await _unitOfWork.Chat.GetChatsById(userId));
            return chats;
        }
    }
}
