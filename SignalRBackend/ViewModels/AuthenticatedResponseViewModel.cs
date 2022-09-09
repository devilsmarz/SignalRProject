using System;

namespace SignalRBackend.WEB.ViewModels
{
    public class AuthenticatedResponseViewModel
    {
        public Int32 UserId { get; set; }
        public String Token { get; set; }
        public String UserName { get; set; }
    }
}
