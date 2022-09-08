using AutoMapper;
using SignalRBackend.BLL.DTO;
using SignalRBackend.BLL.Interfaces;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void Delete(Int32 id)
        {
            _unitOfWork.Message.Delete(_unitOfWork.Message.GetById(id));
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
    }
}
