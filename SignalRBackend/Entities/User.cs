﻿using System;
using System.Collections.Generic;

namespace SignalRBackend.Entities
{
    public class User
    {
        public Int32 Id { get; set; }
        [System.ComponentModel.DataAnnotations.MinLength(3)]
        public String UserName { get; set; }
        public IEnumerable<Chat> Chats { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
