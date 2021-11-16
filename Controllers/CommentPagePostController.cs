using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_network.Data;
using Social_network.Models;

namespace Social_network.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentPagePostController : ControllerBase {

        private readonly MXHContext _context;

        public CommentPagePostController(MXHContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentPagePost>>> GetUserMxh()
        {
            return await _context.CommentPagePosts.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<CommentPagePost>> PostUserMxh(CommentPagePost commentPagePost)
        {
            _context.CommentPagePosts.Add(commentPagePost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostUserMxh", new { commentPagePost.postId, commentPagePost.userId});
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCommentPagePost( [FromQuery] int postId, [FromQuery] int userId)
        {
            var like = await _context.UserLikePages.FindAsync(postId, userId);
            if (like == null)
            {
                return NotFound();
            }

            _context.UserLikePages.Remove(like);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}