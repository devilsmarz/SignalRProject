using System;
using System.Collections.Generic;

namespace SignalRBackend.DAL.DomainModels
{
    public class Chat
    {
        public Int32? Id { get; set; }
        [System.ComponentModel.DataAnnotations.MinLength(3)]
        public String Name { get; set; }
        public Int32 ChatType { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
