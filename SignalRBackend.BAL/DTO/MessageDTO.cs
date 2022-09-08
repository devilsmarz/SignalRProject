﻿using SignalRBackend.DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRBackend.BLL.DTO
{
    public class MessageDTO
    {
        public Int32? Id { get; set; }
        public Int32 ChatId { get; set; }
        public Int32 UserId { get; set; }
        public String MessageText { get; set; }
        public DateTime ActivityDate { get; set; }
    }
}