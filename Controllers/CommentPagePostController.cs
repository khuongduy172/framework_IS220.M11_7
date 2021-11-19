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
    public class CommentPagePostController : ControllerBase
    {
        private readonly MXHContext _context;

        public CommentPagePostController(MXHContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentPagePost>>> GetAllCommentPagePost([FromQuery] int postId)
        {
            var result = await _context.CommentPagePosts.Where(p => p.postId == postId).ToListAsync();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<CommentPagePost>> CommentPost(CommentPagePost comment)
        {
            _context.CommentPagePosts.Add(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut]
        public async Task<IActionResult> PutCommentPagePost( [FromQuery] int userId, [FromQuery] int postId, CommentPagePost comment)
        {
            if (userId != comment.userId && postId != comment.postId)
            {
                return BadRequest();
            }

            var check = await _context.CommentPagePosts.FindAsync(postId, userId);
            if (check == null)
            {
                return NotFound();
            }

            _context.Entry(comment).State = EntityState.Modified;

            return NoContent();
        }

        

        [HttpDelete]
        public async Task<IActionResult> DeleteCommentPagePost([FromQuery] int userId, [FromQuery] int postId)
        {
            var comment = await _context.CommentPagePosts.FindAsync(postId, userId);
            if (comment == null)
            {
                return NotFound();
            }

            _context.CommentPagePosts.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}