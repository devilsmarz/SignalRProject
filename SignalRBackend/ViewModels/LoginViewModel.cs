using System;
using System.ComponentModel.DataAnnotations;

namespace SignalRBackend.WEB.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public String UserName { get; set; }
    }
}
