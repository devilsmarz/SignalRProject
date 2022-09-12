using System;
using System.ComponentModel.DataAnnotations;

namespace SignalRBackend.WEB.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(1)]
        public String UserName { get; set; }
    }
}
