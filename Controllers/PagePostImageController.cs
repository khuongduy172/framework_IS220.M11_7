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
    public class PagePostImageController : ControllerBase
    {
        private readonly MXHContext _context;

        public PagePostImageController(MXHContext context)
        {
            _context = context;
        }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<PagePostImage>>> GetAllPageImage([FromQuery] int pageId)
        // {
        //     var pageid = new SqlParameter("pageid", pageId);
        //     var sql = $"SELECT id_image, post_id " +
        //         $"FROM Page_post_image PI, Page_post P " +
        //         $"WHERE PI.post_id = P.id     " +
        //         $"AND P.page_id = @pageid;";
        //     var result = await _context.PagePostImages.FromSqlRaw(sql, pageid).ToListAsync();
        //     return result;
        // }

        // [HttpGet]
        // [Route("getpostimage")]

        // public async Task<ActionResult<IEnumerable<PagePostImage>>> GetPostImage( [FromQuery] int postId)
        // {
        //     var postImage = await _context.PagePostImages.Where( i => i.postId == postId).ToListAsync();

        //     if (postImage == null)
        //     {
        //         return NotFound();
        //     }

        //     return postImage;
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutUserMxh(int id, UserMxh userMxh)
        // {
        //     if (id != userMxh.id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(userMxh).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!UserMxhExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // [HttpPost]
        // public async Task<ActionResult<UserMxh>> PostUserMxh(UserMxh userMxh)
        // {
        //     _context.UserMxhs.Add(userMxh);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetUserMxh", new { id = userMxh.id }, userMxh);
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteUserMxh(int id)
        // {
        //     var userMxh = await _context.UserMxhs.FindAsync(id);
        //     if (userMxh == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.UserMxhs.Remove(userMxh);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }
    }
}