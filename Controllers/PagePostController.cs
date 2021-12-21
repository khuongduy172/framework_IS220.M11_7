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

        [HttpGet("{id}")]
        public async Task<ActionResult<PagePost>> GetPagePost(string id)
        {
            var pagePost = await _context.PagePosts.FindAsync(id);

            if (pagePost == null)
            {
                return NotFound();
            }

            return pagePost;
        }

        [HttpPost]
        [Route("createPagePost")]
        public async Task<ActionResult<PagePost>> AddPagePostByTime(PagePost pagePost)
        {
            PagePost newPagePost = new PagePost();
            newPagePost.pageId = pagePost.pageId;
            newPagePost.content = pagePost.content;
            newPagePost.createAt = DateTime.Now;
            try {
                _context.PagePosts.Add(newPagePost);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetAllPagePost", new {newPagePost});
            } catch (Exception e) {
                return BadRequest();
            }
        }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<PagePost>>> GetAllPagePostById([FromQuery] string id)
        // {
        //     var result = await _context.PagePosts.Where(i => i.id == id).ToListAsync();
        //     return result;
        // }
        // [HttpGet]
        // [Route("getPagePost")]
        // public async Task<IQueryable> GetAllPagePost()
        // {
        //     //var id = new SqlParameter("id", Id);
        //     //var sql = $"select content, pp.create_at, last_name " +
        //     //          $"from Page_post pp, Page_MXH pmxh, User_MXH umxh " +
        //     //          $"where pp.page_id = pmxh.id and umxh.id = pmxh.owner_id"; 
        //     //var result = await _context.PagePosts.FromSqlRaw(sql).ToListAsync();
        //     //return result;
        //     var query = from pp in _context.PagePosts
        //                 join pmxh in _context.PageMxhs on pp.pageId equals pmxh.id 
        //                 join umxh in _context.UserMxhs on pmxh.ownerId equals umxh.id 
        //                 select new { pp.content, pp.createAt, umxh.lastName};
        //     return query;
        // }

        // [HttpPost]
        // public async Task<ActionResult<PagePost>> AddPagePost(PagePost pagePost)
        // {
        //     _context.PagePosts.Add(pagePost);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }


        // [HttpPut]
        // public async Task<IActionResult> PutPagePost( [FromQuery] int id, [FromQuery] int pageId, PagePost pagePost)
        // {
        //     if (id != pagePost.id && pageId != pagePost.pageId)
        //     {
        //         return BadRequest();
        //     }

        //     var check = await _context.PagePosts.FindAsync(id, pageId);
        //     if (check == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Entry(pagePost).State = EntityState.Modified;

        //     return NoContent();
        // }

        

        // [HttpDelete]
        // public async Task<IActionResult> DeletePagePost([FromQuery] int id, [FromQuery] int pageId)
        // {
        //     var pagePost = await _context.PagePosts.FindAsync(id, pageId);
        //     if (pagePost == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.PagePosts.Remove(pagePost);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }
    }
}