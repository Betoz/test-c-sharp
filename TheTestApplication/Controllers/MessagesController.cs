using Microsoft.AspNetCore.Mvc;
using TheTestApplication.Models;
using System.Collections.Generic;

namespace TheTestApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly MessageDbContext _context;

        public MessagesController(MessageDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MessageEntry>> GetMessages()
        {
            return _context.Messages;
        }

        [HttpGet("{id}")]
        public ActionResult<MessageEntry> GetMessage(long id)
        {
            var message = _context.Messages.Find(id);
            if (message == null)
            {
                return NotFound();
            }
            return message;
        }

        [HttpPost]
        public ActionResult<MessageEntry> PostMessage(MessageEntry message)
        {
            System.Console.WriteLine(message.Message);
            if (message.Message == null)
            {
                return BadRequest();
            }
            _context.Messages.Add(message);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMessages), new { id = message.Id }, message);
        }

        [HttpDelete("{id}")]
        public ActionResult<MessageEntry> DeleteMessage(long id)
        {
            var message = _context.Messages.Find(id);
            if (message == null)
            {
                return BadRequest();
            }
            _context.Messages.Remove(message);
            _context.SaveChanges();
            return message;
        }
    }
}
