using AutoMapper;
using SignalRBackend.BLL.DTO;
using SignalRBackend.BLL.Interfaces;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
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

        public void Delete(Int32 id, Boolean onlyme)
        {
            if (onlyme == false)
            {
                _unitOfWork.Message.Delete(_unitOfWork.Message.GetById(id));
            }
            else
            {
                _unitOfWork.Message.GetById(id).IsDeletedForMe = true;
            }
            _unitOfWork.Save();
        }

        public void Add(MessageDTO message)
        {
            _unitOfWork.Message.Add(_mapper.Map<Message>(message));
            _unitOfWork.Save();
        }

        public void Update(MessageDTO message)
        {
            _unitOfWork.Message.Update(_mapper.Map<Message>(message));
            _unitOfWork.Save();
        }

        public MessageDTO InsertOrUpdateAndGet(MessageDTO message)
        {
           return _mapper.Map<MessageDTO>(_unitOfWork.Message.InsertOrUpdateAndGet(_mapper.Map<Message>(message)));
        }

        public void GetAll(Int32 chatid, Int32 userid)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<MessageDTO>> GetMessages(Int32 chatid, Int32 userid)
        {
            return _mapper.Map<IEnumerable<MessageDTO>>(await _unitOfWork.Message.GetMessages(chatid, userid));
        }

        public async Task<IEnumerable<MessageDTO>> UploadUpper(int id)
        {
            return _mapper.Map<IEnumerable<MessageDTO>>(await _unitOfWork.Message.UploadUpper(id));
        }
    }
}
