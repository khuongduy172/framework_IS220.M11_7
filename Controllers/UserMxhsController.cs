using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_network.Data;
using Social_network.Models;

namespace Social_network.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<IEnumerable<UserMxh>>> GetUserMxh()
        {
            return await _context.UserMxhs.ToListAsync();
        }

        // GET: api/UserMxhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserMxh>> GetUserMxh(int id)
        {
            var userMxh = await _context.UserMxhs.FindAsync(id);

            if (userMxh == null)
            {
                return NotFound();
            }

            return userMxh;
        }

        // PUT: api/UserMxhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserMxh(int id, UserMxh userMxh)
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
        public async Task<ActionResult<UserMxh>> PostUserMxh(UserMxh userMxh)
        {
            _context.UserMxhs.Add(userMxh);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserMxh", new { id = userMxh.id }, userMxh);
        }

        // DELETE: api/UserMxhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserMxh(int id)
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

        private bool UserMxhExists(int id)
        {
            return _context.UserMxhs.Any(e => e.id == id);
        }
    }
}
