using AutoMapper;
using SignalRBackend.BLL.DTO;
using SignalRBackend.BLL.Interfaces;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void DeleteMessage(MessageDTO message)
        {
            Message messageDB = _mapper.Map<Message>(message);
            if (message.IsDeletedForMe == false)
            {
                _unitOfWork.Message.Delete(messageDB);
            }
            else
            {
                _unitOfWork.Message.AttachEntity(messageDB);
                messageDB.IsDeletedForMe = true;
            }
            _unitOfWork.Save();
        }

        public void UpdateMessage(MessageDTO message)
        {
            _unitOfWork.Message.Update(_mapper.Map<Message>(message));
            _unitOfWork.Save();
        }

        public MessageDTO AddMessage(MessageDTO message)
        {
            Message messageDB = _mapper.Map<Message>(message);
            _unitOfWork.Message.Add(_mapper.Map<Message>(messageDB));
            _unitOfWork.Save();
            MessageDTO result = _mapper.Map<MessageDTO>(messageDB);
            return result;
        }

        public async Task<PageInfoDTO> TakeMessages(Int32? page, Int32 userid, Int32 chatid)
        {
            IEnumerable<MessageDTO> messages = _mapper.Map<IEnumerable<MessageDTO>>(await _unitOfWork.Message.TakeMessages(userid, chatid));

            Int32 numOfMessages = messages.Count();
            Int32 totalPages = numOfMessages % 20 == 0 ? numOfMessages / 20 : (numOfMessages / 20) + 1;

            return page != null 
                ? new PageInfoDTO
                {
                    CurrentPageNumber = (Int32)page,
                    Messages = messages.Skip(((Int32)page - 1) * 20),
                }
                : new PageInfoDTO
                {
                    CurrentPageNumber = totalPages,
                    Messages = messages.Skip((totalPages-1)*20),
                };
        }
    }
}
