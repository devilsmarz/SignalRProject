using System;

namespace SignalRBackend.WEB.ViewModels
{
    public class AuthenticatedResponseViewModel
    {
        public String Token { get; set; }
        public Int32 UserId { get; set; }
    }
}
