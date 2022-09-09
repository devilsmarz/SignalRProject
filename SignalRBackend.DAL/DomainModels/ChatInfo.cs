using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRBackend.DAL.DomainModels
{
    public class ChatInfo
    {
        public Int32 TotalPages { get; set; }
        public Int32 CurrentPageNumber { get; set; }
        public IEnumerable<Message> MessagesOnPage { get; set; }
    }
}
