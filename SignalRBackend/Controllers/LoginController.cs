using Microsoft.AspNetCore.Mvc;

namespace SignalRBackend.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {

        }
    }
}
