using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        public async Task<ActionResult<IEnumerable<Follow>>> GetAllFollowOfUser([FromQuery] int id)
        {
            var userid = new SqlParameter("id", id);
            var sql = $"SELECT id, follower_id " +
                $"FROM User_MXH U, Follow F " +
                $"WHERE U.id = F.user_id " +
                $"AND U.id = @id;";
            var result = await _context.Follows.FromSqlRaw(sql, userid).ToListAsync();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Follow>> PostFollow(Follow follow)
        {
            _context.Follows.Add(follow);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetAllFollow", new { follow.userId, follow.followerId},follow);
            return NoContent();

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