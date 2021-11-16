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

            return NoContent();
        }
    }
}