using SignalRBackend.BLL.DTO;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBackend.BLL.Interfaces
{
    public interface IMessageService
    {
        public void DeleteMessage(MessageDTO message);
        public void UpdateMessage(MessageDTO message);
        Task<PageInfoDTO> TakeMessages(Int32? page, Int32 userid, Int32 chatid);
        public MessageDTO AddMessage(MessageDTO message);
        public Boolean IsUserInChat(Int32 userid);
    }
}
