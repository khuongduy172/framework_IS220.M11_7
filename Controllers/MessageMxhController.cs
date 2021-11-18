using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_network.Data;
using Social_network.Models;

namespace Social_network.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageMxhController : ControllerBase {

        private readonly MXHContext _context;

        public MessageMxhController(MXHContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Friend>>> GetAllMessageMxh()
        {
            return await _context.Friends.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<MessageMxh>> PostMessageMxh(MessageMxh message)
        {
            _context.MessageMxhs.Add(message);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetAllMessageMxh", new { message.senderId, message.receiverId},message);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessageMxh(int senderId, int receiverId)
        {
            var message = await _context.MessageMxhs.FindAsync(senderId, receiverId);
            if (message == null)
            {
                return NotFound();
            }

            _context.MessageMxhs.Remove(message);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}