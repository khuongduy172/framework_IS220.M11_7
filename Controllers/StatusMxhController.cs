using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social_network.Data;
using Social_network.Models;

namespace Social_network.Controllers 
{

  [ApiController]
  [Route("api/[controller]")]

  public class StatusMxhController : ControllerBase
  {
    private readonly MXHContext _context;
    public StatusMxhController(MXHContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatusMxh>>> GetStatusMxh([FromQuery] int statusId)
    {
      return await _context.StatusMxhs.Where(s => s.statusId == statusId).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<StatusMxh>> StatusMxh(StatusMxh statusMxh)
    {
      
      _context.StatusMxhs.Add(statusMxh);
      await _context.SaveChangesAsync();
      return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> PutStatusMxh( [FromQuery] int ownerId, [FromQuery] int statusId, StatusMxh statusMxh)
    {
      if (ownerId != statusMxh.ownerId && statusId != statusMxh.statusId)
      {
        return BadRequest();
      }

      var check = await _context.StatusMxhs.FindAsync(statusId, ownerId);
      if (check == null)
      {
        return NotFound();
      }

      _context.Entry(statusMxh).State = EntityState.Modified;
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteStatusMxh( [FromQuery] int ownerId, [FromQuery] int statusId)
    {
      var react = await _context.StatusMxhs.FindAsync(ownerId, statusId);
      if (react == null)
      {
        return NotFound();
      }

      _context.StatusMxhs.Remove(react);
      await _context.SaveChangesAsync();
      return NoContent();
    }
  }
}