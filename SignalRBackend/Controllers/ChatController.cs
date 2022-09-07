using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRBackend.WEB.Configurations.HubConfig;
using SignalRBackend.WEB.ViewModels;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRBackend.WEB.Controllers
{
    [Route("chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hub;
        public ChatController(IHubContext<ChatHub> hub)
        {
            _hub = hub;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}"), Authorize]
        public IActionResult Get(int id)
        {
            var a = _hub.Clients.All.SendAsync("chatData", "messages");
            return Ok(new { Message = "Request Completed}" });
        }

        [HttpPost, Authorize]
        public async Task SendMessage(MessageViewModel message)
        {
            //additional business logic 

            await _hub.Clients.All.SendAsync("messageReceivedFromApi", message);

            //additional business logic 
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}"), Authorize]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}"), Authorize]
        public void Delete(int id)
        {
        }
    }
}
