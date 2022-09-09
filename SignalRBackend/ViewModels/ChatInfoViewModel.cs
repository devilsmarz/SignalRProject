using System;
using System.Collections.Generic;

namespace SignalRBackend.WEB.ViewModels
{
    public class ChatInfoViewModel
    {
        public Int32 TotalPages { get; set; }
        public Int32 CurrentPageNumber { get; set; }
        IEnumerable<MessageViewModel> MessagesOnPage { get; set; }
    }
}
