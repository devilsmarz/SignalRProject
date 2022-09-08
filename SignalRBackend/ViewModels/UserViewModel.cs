﻿using SignalRBackend.DAL.DomainModels;
using System.Collections.Generic;
using System;

namespace SignalRBackend.WEB.ViewModels
{
    public class UserViewModel
    {
        public Int32? Id { get; set; }
        [System.ComponentModel.DataAnnotations.MinLength(3)]
        public String UserName { get; set; }
        public IEnumerable<ChatViewModel> Chats { get; set; }
        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}