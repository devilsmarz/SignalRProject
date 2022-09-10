using System;
using System.Collections.Generic;

namespace SignalRBackend.WEB.ViewModels
{
    public class PageInfoViewModel
    {
        public Int32 CurrentPageNumber { get; set; }
        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}
