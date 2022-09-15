using SignalRBackend.BLL.DTO;

namespace SignalRBackend.BLL.Interfaces
{
    public interface IAuthorizationService
    {
        AuthenticatedResponseDTO Authorize(LoginDTO user);
    }
}
