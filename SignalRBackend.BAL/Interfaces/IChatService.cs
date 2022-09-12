using SignalRBackend.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRBackend.BLL.Interfaces
{
    public interface IChatService
    {
        Task<IEnumerable<ChatDTO>> GetChatsById(Int32 userId);
    }
}
