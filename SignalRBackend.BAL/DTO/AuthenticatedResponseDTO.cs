using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRBackend.BLL.DTO
{
    public class AuthenticatedResponseDTO
    {
        public String Token { get; set; }
        public Int32 UserId { get; set; }
    }
}
