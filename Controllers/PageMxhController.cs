<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Social_network.Models;
using Social_network.Services;

namespace Social_network.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PageMxhController : ControllerBase
    {
        public PageMxhController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<PageMxh>> GetAll() =>
            PageMxhService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<PageMxh> Get(int id)
        {
            var pageMxh = PageMxhService.Get(id);

            if(pageMxh == null)
                return NotFound();

            return pageMxh;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(PageMxh pageMxh)
        {            
            PageMxhService.Add(pageMxh);
            return CreatedAtAction(nameof(Create), new { id = pageMxh.Id }, pageMxh);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, PageMxh pageMxh)
        {
            if (id != pageMxh.Id)
                return BadRequest();

            var existingPageMxh = PageMxhService.Get(id);
            if(existingPageMxh is null)
                return NotFound();

            PageMxhService.Update(pageMxh);           

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pageMxh = PageMxhService.Get(id);

            if (pageMxh is null)
                return NotFound();

            PageMxhService.Delete(id);
=======
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
    public class PageMxhController : ControllerBase {

        private readonly MXHContext _context;

        public PageMxhController(MXHContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageMxh>>> GetPageMxh()
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
>>>>>>> khuongduy

            return NoContent();
        }
    }
}