using AutoMapper;
using SignalRBackend.BLL.DTO;
using SignalRBackend.BLL.Interfaces;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRBackend.BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DeleteMessage(Int32 messageId, Boolean isDeletedOnlyForCreator)
        {
            Message messageDB = await _unitOfWork.Message.GetById(messageId);

            if (isDeletedOnlyForCreator == false)
            {
                _unitOfWork.Message.UpdateGraph(messageDB);
                _unitOfWork.Message.Delete(messageDB);
            }
            else
            {
                messageDB.IsDeletedOnlyForCreator = true;

            }
            await _unitOfWork.SaveAsync();
            _unitOfWork.Message.DetachEntity(messageDB);
        }

        public MessageDTO AddOrUpdateMessage(MessageDTO message)
        {
            Message messageDB = _mapper.Map<Message>(message);
            _unitOfWork.Message.Update(messageDB);
            _unitOfWork.Save();
            _unitOfWork.Message.DetachEntity(messageDB);
            return _mapper.Map<MessageDTO>(messageDB); ;
        }

        public async Task<PageInfoDTO> GetMessages(Int32? page, Int32 userId, Int32 chatId)
        {
            IEnumerable<MessageDTO> messages = _mapper.Map<IEnumerable<MessageDTO>>(await _unitOfWork.Message.GetMessages(userId, chatId));

            Int32 numOfMessages = messages.Count();
            Int32 totalPages = numOfMessages % 20 == 0 ? numOfMessages / 20 : (numOfMessages / 20) + 1;

            return page != null
                ? new PageInfoDTO
                {
                    CurrentPageNumber = (Int32)page,
                    Messages = messages.Skip(((Int32)page - 1) * 20).Take(20),
                }
                : new PageInfoDTO
                {
                    CurrentPageNumber = totalPages,
                    Messages = messages.Skip((totalPages - 1) * 20),
                };
        }

        public async Task<Boolean> IsUserInChat(Int32 userId, Int32 chatId)
        {
            Chat chat = await _unitOfWork.Chat.GetById(chatId);
            return chat.Users.Any(user => user.Id == userId);
        }
    }
}
