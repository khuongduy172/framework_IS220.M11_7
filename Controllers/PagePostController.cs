using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Social_network.Models;
using Social_network.Services;

namespace Social_network.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagePostController : ControllerBase
    {
        public PagePostController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<PagePost>> GetAll() =>
            PagePostService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<PagePost> Get(int id)
        {
            var pagepost = PagePostService.Get(id);

            if(pagepost == null)
                return NotFound();

            return pagepost;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(PagePost pagepost)
        {            
            PagePostService.Add(pagepost);
            return CreatedAtAction(nameof(Create), new { id = pagepost.Id }, pagepost);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, PagePost pagepost)
        {
            if (id != pagepost.Id)
                return BadRequest();

            var existingPagepost = PagePostService.Get(id);
            if(existingPagepost is null)
                return NotFound();

            PagePostService.Update(pagepost);           

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pagepost = PagePostService.Get(id);

            if (pagepost is null)
                return NotFound();

            PagePostService.Delete(id);

            return NoContent();
        }
    }
}