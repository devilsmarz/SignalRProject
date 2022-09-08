using SignalRBackend.DAL.DomainModels;
using System.Collections.Generic;
using System;

namespace SignalRBackend.WEB.ViewModels
{
    public class ChatViewModel
    {
        public Int32? Id { get; set; }
        [System.ComponentModel.DataAnnotations.MinLength(3)]
        public String Name { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
