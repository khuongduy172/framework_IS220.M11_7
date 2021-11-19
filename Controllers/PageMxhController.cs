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
    public class PageMxhController : ControllerBase
    {
        private readonly MXHContext _context;

        public PageMxhController(MXHContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageMxh>>> GetAllPageMxh([FromQuery] int id)
        {
            var result = await _context.PageMxhs.Where(p => p.id == id).ToListAsync();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<PageMxh>> AddPageMxh(PageMxh pageMxh)
        {
            _context.PageMxhs.Add(pageMxh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutPageMxh( [FromQuery] int id, PageMxh pageMxh)
        {
            if (id != pageMxh.id)
            {
                return BadRequest();
            }

            var check = await _context.PageMxhs.FindAsync(id);
            if (check == null)
            {
                return NotFound();
            }

            _context.Entry(pageMxh).State = EntityState.Modified;

            return NoContent();
        }

        

        [HttpDelete]
        public async Task<IActionResult> DeletePageMxh([FromQuery] int id)
        {
            var pageMxh = await _context.PageMxhs.FindAsync(id);
            if (pageMxh == null)
            {
                return NotFound();
            }

            _context.PageMxhs.Remove(pageMxh);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}