using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_network.Data;
using Social_network.Models;
using BC = BCrypt.Net.BCrypt;


namespace Social_network.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMxhsController : ControllerBase
    {
        private readonly MXHContext _context;

        public UserMxhsController(MXHContext context)
        {
            _context = context;
        }

        // GET: api/UserMxhs
        [HttpGet]
        public IQueryable GetUserMxh()
        {
            var query = from u in _context.UserMxhs
                        where u.isDeleted != true
                        select new {
                            u.id,
                            u.userName,
                            u.email,
                            u.phone,
                            u.firstName,
                            u.lastName,
                            u.avatar,
                            u.coverImage,
                            u.dateOfBirth,
                            u.createdAt,
                            u.deletedAt,
                            u.isDeleted,
                            u.gender,
                        };
            return query;
        }

        // GET: api/UserMxhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserMxh>> GetUserMxh(string id)
        {
            var userMxh = await _context.UserMxhs.FindAsync(id);

            if (userMxh == null)
            {
                return NotFound();
            }

            return userMxh;
        }

        [HttpGet]
        [Route("getUserMxh")]
        public async Task<IQueryable> GetUserMXH2()
        {
            var query = from umxh in _context.UserMxhs
                        select new { umxh.phone, umxh.firstName, umxh.lastName, umxh.dateOfBirth, umxh.gender};
            return query;
        }

        [Authorize]
        [HttpPut]
        [Route("putUserMxh")]
        public async Task<IActionResult> PutUserMXH2(UserMxh userMxh)
        {
            var userId = HttpContext.User.Claims.Single(u=> u.Type == "Id").Value;
            var query = (from umxh in _context.UserMxhs
                        where umxh.id == userId
                        select umxh).FirstOrDefault();
            if(userMxh.firstName != null) {
                query.firstName = userMxh.firstName;
            }
            if(userMxh.lastName != null) {
                query.lastName = userMxh.lastName;
            }
            if(userMxh.phone != null) {
                query.phone = userMxh.phone;
            }
            if(userMxh.dateOfBirth != null) {
                query.dateOfBirth = userMxh.dateOfBirth;
            }
            if(userMxh.gender != null) {
                query.gender = userMxh.gender;
            }
            if(userMxh.avatar != null) {
                query.avatar = userMxh.avatar;
            }
            if(userMxh.coverImage != null) {
                query.coverImage = userMxh.coverImage;
            }
            
            await _context.SaveChangesAsync();
            return Ok(query);
        }

        // PUT: api/UserMxhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserMxh(string id, UserMxh userMxh)
        {
            if (id != userMxh.id)
            {
                return BadRequest();
            }

            _context.Entry(userMxh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserMxhExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserMxhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserMxh>> PostUserMxh(CreateUserModel userMxh)
        {
            var hashedPassword = BC.HashPassword(userMxh.userPassword);
            UserMxh newUser = new UserMxh();
            Guid g = Guid.NewGuid();
            newUser.id = g.ToString();
            newUser.userName = userMxh.userName;
            newUser.email = userMxh.email;
            newUser.phone = userMxh.phone;
            newUser.firstName = userMxh.firstName;
            newUser.lastName = userMxh.lastName;
            newUser.dateOfBirth = userMxh.dateOfBirth;
            newUser.gender = userMxh.gender;
            newUser.userPassword = hashedPassword;
            newUser.createdAt = DateTime.Now;
            newUser.avatar = "https://firebasestorage.googleapis.com/v0/b/social-network-b45a2.appspot.com/o/images%2F1640339659056-avatarclone.jpg?alt=media&token=d7fe9cea-b9be-4bc5-b04f-afb03ce5784a";
            newUser.coverImage = "https://firebasestorage.googleapis.com/v0/b/social-network-b45a2.appspot.com/o/images%2F1640339725939-anhbiaclone.jpg?alt=media&token=f477f24e-6df4-47ed-98df-9b14add330b6";
            try{
                _context.UserMxhs.Add(newUser);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUserMxh", new { id = newUser.id }, newUser);
            } catch {
                return BadRequest();
            }

        }

        // // DELETE: api/UserMxhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserMxh(string id)
        {
            var userMxh = await _context.UserMxhs.FindAsync(id);
            if (userMxh == null)
            {
                return NotFound();
            }
            _context.UserMxhs.Remove(userMxh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserMxhExists(string id)
        {
            return _context.UserMxhs.Any(e => e.id == id);
        }

        [Authorize]
        [HttpGet]
        [Route("me")]
        public IActionResult GetMe(){
            var userId = HttpContext.User.Claims.Single(u=> u.Type == "Id").Value;
            var query = from u in _context.UserMxhs
                        where u.id == userId
                        select new {
                            u.id,
                            u.userName,
                            u.email,
                            u.phone,
                            u.firstName,
                            u.lastName,
                            u.avatar,
                            u.coverImage,
                            u.dateOfBirth,
                            u.createdAt,
                            u.deletedAt,
                            u.isDeleted,
                            u.gender,
                        };
            if(query is null) {
                return NotFound();
            } else {
                return Ok(query.First());
            }
        }

        [Authorize]
        [HttpGet]
        [Route("friend")]
        public IActionResult GetFriend(){
            var userId = HttpContext.User.Claims.Single(u=> u.Type == "Id").Value;
            var query = from f in _context.Friends
                        where f.userId == userId && 
                            (from t in _context.Friends
                            where t.friendId == userId 
                            select t.friendId
                            ).Contains(f.userId)
                        select new {
                            f.userFriend.avatar,
                            f.userFriend.id,
                            f.userFriend.firstName,
                            f.userFriend.lastName,
                        };
            if(query is null) {
                return NotFound();
            } else {
                return Ok(query);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("get-all-image-by-id")]
        public IActionResult GetAllImage(string userId){
            var userIdToken = HttpContext.User.Claims.Single(u=> u.Type == "Id").Value;
            var query = from s in _context.StatusMxhs
                        join i in _context.StatusImages on s.statusId equals i.statusId
                        where s.ownerId == userId
                        select i;
            bool isOwnner;
            if(userId == userIdToken) {
                isOwnner = true;
            } else {
                isOwnner = false;
            }
            if(query is null) {
                return NotFound();
            } else {
                return Ok(new {imgList = query, isOwnner});
            }
        }
    }
}
