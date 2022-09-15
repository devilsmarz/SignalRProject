using System;
using System.Collections.Generic;

namespace SignalRBackend.BLL.DTO
{
    public class PageInfoDTO
    {
        public Int32 CurrentPageNumber { get; set; }
        public IEnumerable<MessageDTO> Messages { get; set; }
    }
}
