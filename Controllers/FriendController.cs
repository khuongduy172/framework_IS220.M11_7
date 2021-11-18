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
    public class FriendController : ControllerBase {

        private readonly MXHContext _context;

        public FriendController(MXHContext context)
        {
            _context = context;
        }

        [HttpGet]
        // public async Task<ActionResult<IEnumerable<Friend>>> GetAllFriend()
        // {
        //     return await _context.Friends.ToListAsync();
        // }
        public async Task<ActionResult<IEnumerable<Friend>>> GetAllFriendOfUser([FromQuery] int id)
        {
            var userid = new SqlParameter("id", id);
            var sql = $"SELECT id, friend_id " +
                $"FROM User_MXH U, Friend Fr " +
                $"WHERE U.id = Fr.user_id " +
                $"AND U.id = @id;";
            var result = await _context.Friends.FromSqlRaw(sql, userid).ToListAsync();
            return result;
        }
        [HttpPost]
        public async Task<ActionResult<Friend>> PostFriend(Friend friend)
        {
            _context.Friends.Add(friend);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetAllFriend", new { friend.userId, friend.friendId},friend);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFriend(int userId, int friendId)
        {
            var friend = await _context.Friends.FindAsync(userId, friendId);
            if (friend == null)
            {
                return NotFound();
            }

            _context.Friends.Remove(friend);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}