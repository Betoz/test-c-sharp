using Microsoft.AspNetCore.Mvc;
using TheTestApplication.Models;

namespace TheTestApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private static readonly MessageLog[] Messages = new MessageLog[]
        {
            new MessageLog{Id=1, Message="Hello world"},
            new MessageLog{Id=2, Message="Come here"},
            new MessageLog{Id=3, Message="Pasta for lunch"},
            new MessageLog{Id=4, Message="Welcome home"},
            new MessageLog{Id=5, Message="There is more"}
        };

        [HttpGet]
        public MessageLog[] GetMessages()
        {
            return Messages;
        }
    }
}
