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

  public class StatusImageController : ControllerBase
  {
    private readonly MXHContext _context;
    public StatusImageController(MXHContext context)
    {
      var _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatusImage>>> GetStatusImage([FromQuery] int statusId)
    {
      return await _context.StatusImages.Where(s => s.statusId == statusId).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<StatusImage>> StatusImage(StatusImage statusImage)
    {
      _context.StatusImages.Add(statusImage);
      await _context.SaveChangesAsync();
      return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> PutStatusImage(  [FromQuery] int statusId, StatusImage statusImage)
    {
      if (statusId != statusImage.statusId)
      {
        return BadRequest();
      }

      var check = await _context.StatusImages.FindAsync(statusId);
      if (check == null)
      {
        return NotFound();
      }

      _context.Entry(statusImage).State = EntityState.Modified;
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteStatusImage( [FromQuery] int statusId)
    {
      var react = await _context.StatusImages.FindAsync(statusId);
            if (react == null)
            {
                return NotFound();
            }

            _context.StatusImages.Remove(react);
            await _context.SaveChangesAsync();

            return NoContent();
    }
  }
}