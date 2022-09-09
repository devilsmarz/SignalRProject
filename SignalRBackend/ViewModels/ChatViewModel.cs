﻿using SignalRBackend.DAL.DomainModels;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace SignalRBackend.WEB.ViewModels
{
    public class ChatViewModel
    {
        public Int32? Id { get; set; }
        [Required]
        [MinLength(3)]
        public String Name { get; set; }
        [Required]
        [Range(1, Int32.MaxValue)]
        public Int32 ChatType { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
