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
    public class NotificationCOntroller : ControllerBase {

        private readonly MXHContext _context;

        public NotificationCOntroller(MXHContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IQueryable GetAllNoti ()
        {
            var me = HttpContext.User.Claims.Single(u=> u.Type == "Id").Value;
            var query = from m in _context.Notifications
                        where m.toId == me
                        orderby m.createAt descending
                        select m;
            return query;
        }
        [HttpPatch]
        [Authorize]
        [Route("read-noti")]
        public async Task<IActionResult> ReadNoti () 
        {
            try {
                var me = HttpContext.User.Claims.Single(u=>u.Type == "Id").Value;
                var query = (from m in _context.Notifications
                            where m.toId == me && m.isRead == false
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
    }
}