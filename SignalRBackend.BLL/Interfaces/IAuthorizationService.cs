using SignalRBackend.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRBackend.BLL.Interfaces
{
    public interface IAuthorizationService
    {
        AuthenticatedResponseDTO Authorize(LoginDTO user);
    }
}
