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
    public class PagePostController : ControllerBase
    {
        private readonly MXHContext _context;

        public PagePostController(MXHContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagePost>>> GetAllPagePost([FromQuery] int id)
        {
            var result = await _context.PagePosts.Where(p => p.id == id).ToListAsync();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<PagePost>> AddPagePost(PagePost pagePost)
        {
            _context.PagePosts.Add(pagePost);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut]
        public async Task<IActionResult> PutPagePost( [FromQuery] int id, [FromQuery] int pageId, PagePost pagePost)
        {
            if (id != pagePost.id && pageId != pagePost.pageId)
            {
                return BadRequest();
            }

            var check = await _context.PagePosts.FindAsync(id, pageId);
            if (check == null)
            {
                return NotFound();
            }

            _context.Entry(pagePost).State = EntityState.Modified;

            return NoContent();
        }

        

        [HttpDelete]
        public async Task<IActionResult> DeletePagePost([FromQuery] int id, [FromQuery] int pageId)
        {
            var pagePost = await _context.PagePosts.FindAsync(id, pageId);
            if (pagePost == null)
            {
                return NotFound();
            }

            _context.PagePosts.Remove(pagePost);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}