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
    public class ReactPagePostController : ControllerBase
    {
        private readonly MXHContext _context;

        public ReactPagePostController(MXHContext context)
        {
            _context = context;
        }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<ReactPagePost>>> GetAllPostReact([FromQuery] int postId)
        // {
        //     var result = await _context.ReactPagePosts.Where(p => p.postId == postId).ToListAsync();
        //     return result;
        // }

        // [HttpPost]
        // public async Task<ActionResult<ReactPagePost>> ReactPost(ReactPagePost react)
        // {
        //     _context.ReactPagePosts.Add(react);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }


        // [HttpPut]
        // public async Task<IActionResult> PutReactPagePost( [FromQuery] int userId, [FromQuery] int postId, ReactPagePost react)
        // {
        //     if (userId != react.userId && postId != react.postId)
        //     {
        //         return BadRequest();
        //     }

        //     var check = await _context.ReactPagePosts.FindAsync(postId, userId);
        //     if (check == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Entry(react).State = EntityState.Modified;

        //     return NoContent();
        // }

        

        // [HttpDelete]
        // public async Task<IActionResult> DeleteUReactPagePost([FromQuery] int userId, [FromQuery] int postId)
        // {
        //     var react = await _context.ReactPagePosts.FindAsync(postId, userId);
        //     if (react == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.ReactPagePosts.Remove(react);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }
    }
}