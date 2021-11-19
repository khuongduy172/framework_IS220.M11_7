using System;
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
    public class UserLikePageController : ControllerBase {

        private readonly MXHContext _context;

        public UserLikePageController(MXHContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLikePage>>> GetUserLikePage([FromQuery] int pageId)
        {
            return await _context.UserLikePages.Where(p => p.pageId == pageId).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<UserLikePage>> UserLikePage(UserLikePage userLikePage)
        {
            _context.UserLikePages.Add(userLikePage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("UserLikePage", new { userLikePage.pageId, userLikePage.userId});
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserLikePage( [FromQuery] int pageId, [FromQuery] int userId)
        {
            var like = await _context.UserLikePages.FindAsync(pageId, userId);
            if (like == null)
            {
                return NotFound();
            }

            _context.UserLikePages.Remove(like);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}