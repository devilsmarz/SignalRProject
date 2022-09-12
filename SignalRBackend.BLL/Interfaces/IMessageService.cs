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
        Task DeleteMessage(Int32 messageId, Boolean isDeletedOnlyForCreator);
        Task<PageInfoDTO> TakeMessages(Int32? page, Int32 userid, Int32 chatid);
        MessageDTO AddOrUpdateMessage(MessageDTO message);
        Task<Boolean> IsUserInChat(Int32 userId, Int32 chatId);
    }
}
