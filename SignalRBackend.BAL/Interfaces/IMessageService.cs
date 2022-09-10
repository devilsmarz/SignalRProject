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
        void DeleteMessage(MessageDTO message);
        void UpdateMessage(MessageDTO message);
        Task<PageInfoDTO> TakeMessages(Int32? page, Int32 userid, Int32 chatid);
        MessageDTO AddMessage(MessageDTO message);
        Task<Boolean> IsUserInChat(Int32 userId, Int32 chatId);
    }
}
