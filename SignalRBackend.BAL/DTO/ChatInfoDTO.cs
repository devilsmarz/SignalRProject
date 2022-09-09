using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRBackend.BLL.DTO
{
    public class ChatInfoDTO
    {
        public Int32 TotalPages { get; set; }
        public Int32 CurrentPageNumber { get; set; }
        IEnumerable<MessageDTO> MessagesOnPage { get; set; }
    }
}
