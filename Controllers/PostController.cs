using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Social_network.Models;
using Social_network.Services;

namespace Social_network.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        public PostController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Post>> GetAll() {
            return PostService.GetAll();
        }

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Post> GetActionResult(int id) {
            var post = PostService.GetById(id);
            if (post is null) {
                return NotFound();
            }
            return post;
        }        

        // POST action
        [HttpPost]
        public IActionResult Create (Post post) {
            PostService.Create(post);
            return Ok();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update (int id, Post post) {
            var exist = PostService.GetById(id);
            if (exist is null) {
                return NotFound();
            }

            PostService.Update(post);
            return Ok();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var post = PostService.GetById(id);

            if (post is null)
                return NotFound();

            PostService.Delete(id);

            return Ok();
        }
    }
}