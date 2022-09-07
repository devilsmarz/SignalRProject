using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRBackend.BLL.DTO;
using SignalRBackend.BLL.Interfaces;
using SignalRBackend.WEB.ViewModels;

namespace SignalRBackend.WEB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        public AuthController(IAuthorizationService authorizationService, IMapper mapper)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel user)
        {
            AuthenticatedResponseViewModel result =_mapper.Map<AuthenticatedResponseViewModel>(_authorizationService.Authorize(_mapper.Map<LoginDTO>(user)));
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
