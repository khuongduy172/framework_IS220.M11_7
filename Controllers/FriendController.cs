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
using Microsoft.AspNetCore.Authorization;


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
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Friend>> PostFriend(Friend friend)
        {
            var me = HttpContext.User.Claims.Single(u=> u.Type == "Id").Value;
            var newFriend = new Friend ();
            newFriend.friendId = friend.friendId;
            newFriend.userId = me;
            _context.Friends.Add(newFriend);

            var check = (from f in _context.Friends
                        where f.friendId == me && f.userId == friend.friendId
                        select f).FirstOrDefault();
            if (check != null) {
                var noti = (from n in _context.Notifications
                            where n.fromId == friend.friendId && n.toId == me && n.type ==  2
                            select n).FirstOrDefault();
                _context.Notifications.Remove(noti);
            }
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetAllFriend", new { friend.userId, friend.friendId},friend);
            return NoContent();
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteFriend(string friendId)
        {
            var userId = HttpContext.User.Claims.Single(u=> u.Type == "Id").Value;
            var friend = (from f in _context.Friends
                            where f.userId == userId && f.friendId == friendId
                            select f).FirstOrDefault();
            var friend2 = (from f in _context.Friends
                            where f.userId == friendId && f.friendId == userId
                            select f).FirstOrDefault();
            if (friend == null && friend2 == null)
            {
                return NotFound();
            }
            if(friend != null) {
                _context.Friends.Remove(friend);
                var noti = (from n in _context.Notifications
                            where n.type == 2 && n.fromId == userId && n.toId == friendId
                            select n).FirstOrDefault();
                if (noti != null) {
                    _context.Notifications.Remove(noti);
                }
            }
            if(friend2 != null) {
                _context.Friends.Remove(friend2);
                var noti = (from n in _context.Notifications
                            where n.type == 2 && n.fromId == friendId && n.toId == userId
                            select n).FirstOrDefault();
                if (noti != null) {
                    _context.Notifications.Remove(noti);
                }
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet]
        [Route("check-friend")]
        public IActionResult CheckFriend (string userId) 
        {
            var me = HttpContext.User.Claims.Single(u=> u.Type == "Id").Value;
            var temp = (from f in _context.Friends
                        where f.userId == me
                        where f.friendId == userId
                        select f.userId).Contains(me);
            var temp1 = (from f in _context.Friends
                        where f.userId == userId
                        where f.friendId == me
                        select f.friendId).Contains(me);
            
            if (temp && temp1) {
                return Ok(new {isFriend = true, isRequest = false, isAccept = false,});
            } 
            if (temp && !temp1) {
                return Ok(new {isFriend = false, isRequest = true, isAccept = false,});
            }
            if (!temp && temp1) {
                return Ok(new {isFriend = false, isRequest = false, isAccept = true,});
            }

            
            return Ok(new {isFriend = false, isRequest = false, isAccept = false,});
        }
    }
}