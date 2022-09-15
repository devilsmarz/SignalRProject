using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SignalRBackend.WEB.ViewModels
{
    public class UserViewModel
    {
        public Int32? Id { get; set; }
        [Required]
        [MinLength(3)]
        public String UserName { get; set; }
        public IEnumerable<ChatViewModel> Chats { get; set; }
        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}
