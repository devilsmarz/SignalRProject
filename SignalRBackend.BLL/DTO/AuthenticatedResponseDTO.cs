﻿using System;

namespace SignalRBackend.BLL.DTO
{
    public class AuthenticatedResponseDTO
    {
        public Int32 UserId { get; set; }
        public String Token { get; set; }
        public String UserName { get; set; }
    }
}
