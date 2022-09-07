using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRBackend.BLL.Interfaces
{
    public interface ILoginService
    {
        IActionResult Login(LoginViewModel user);
    }
}
