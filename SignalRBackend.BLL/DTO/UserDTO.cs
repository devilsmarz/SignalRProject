using System;
using System.Collections.Generic;

namespace SignalRBackend.BLL.DTO
{
    public class UserDTO
    {
        public Int32? Id { get; set; }
        public String UserName { get; set; }
        public IEnumerable<ChatDTO> Chats { get; set; }
        public IEnumerable<MessageDTO> Messages { get; set; }
    }
}
