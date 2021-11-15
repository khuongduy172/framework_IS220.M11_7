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
    public class FollowController : ControllerBase {

        private readonly MXHContext _context;

        public FollowController(MXHContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Follow>>> GetUserMxh()
        {
            return await _context.Follows.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Follow>> PostUserMxh(Follow follow)
        {
            _context.Follows.Add(follow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserMxh", new { follow.userId, follow.followerId},follow);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFollow( int userId, int followerId)
        {
            var follow = await _context.Follows.FindAsync(userId, followerId);
            if (follow == null)
            {
                return NotFound();
            }

            _context.Follows.Remove(follow);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}