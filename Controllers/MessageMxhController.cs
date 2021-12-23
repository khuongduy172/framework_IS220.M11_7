using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Social_network.Data;
using Social_network.Models;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public IQueryable GetAllMes (string userId)
        {
            var me = HttpContext.User.Claims.Single(u=> u.Type == "Id").Value;
            var query = from m in _context.MessageMxhs
                        where m.senderId == me || m.receiverId == userId
                        orderby m.createAt descending
                        select m;
            return query;
        }

        [Authorize]
        [HttpGet]
        [Route("get-list-mes")]
        public IActionResult GetListMes ()
        {
            var me = HttpContext.User.Claims.Single(u=> u.Type == "Id").Value;
            var query = (from m in _context.MessageMxhs
                        where m.receiverId == me
                        orderby m.createAt
                        select m.senderId).Distinct().ToList();
            List<MessageMxh> result = new List<MessageMxh>();
            foreach (var item in query)
            {
                var temp = from m in _context.MessageMxhs
                            where m.senderId == item && m.receiverId == me
                            select m;
                var max = temp.Max(i => i.createAt);
                var final = (from m in _context.MessageMxhs
                            where m.createAt == max
                            where m.senderId == item
                            where m.receiverId == me
                            select m).FirstOrDefault();
                result.Add(final);
            }
            
            return Ok(result);
        }

        [HttpPatch]
        [Authorize]
        [Route("read-mesage")]
        public async Task<IActionResult> ReadMessage (string userId) 
        {
            try {
                var me = HttpContext.User.Claims.Single(u=>u.Type == "Id").Value;
                var query = (from m in _context.MessageMxhs
                            where m.senderId == userId && m.receiverId == me
                            select m).ToList();
                foreach (var i in query) 
                {
                    i.isRead = true;
                }
                await _context.SaveChangesAsync();
                return NoContent();
            } catch {
                return BadRequest();
            }
        }
        // public async Task<ActionResult<IEnumerable<MessageMxh>>> GetAllMessageOfUser([FromQuery] int id)
        // {
        //     var userid = new SqlParameter("id", id);
        //     var sql = $"SELECT id, receiver_id " +
        //         $"FROM User_MXH U, MessageMxh MM " +
        //         $"WHERE U.id = MM.receiver_id " +
        //         $"AND U.id = @id;";
        //     var result = await _context.MessageMxhs.FromSqlRaw(sql, userid).ToListAsync();
        //     return result;
        // }
        // [HttpPost]
        // public async Task<ActionResult<MessageMxh>> PostMessageMxh(MessageMxh message)
        // {
        //     _context.MessageMxhs.Add(message);
        //     await _context.SaveChangesAsync();

        //     // return CreatedAtAction("GetAllMessageMxh", new { message.senderId, message.receiverId},message);
        //     return NoContent();
        // }

        // [HttpDelete]
        // public async Task<IActionResult> DeleteMessageMxh(int senderId, int receiverId)
        // {
        //     var message = await _context.MessageMxhs.FindAsync(senderId, receiverId);
        //     if (message == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.MessageMxhs.Remove(message);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }
    }
}