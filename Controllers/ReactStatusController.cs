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

  public class ReactStatusController : ControllerBase
  {
    private readonly MXHContext _context;
    public ReactStatusController(MXHContext context)
    {
      var _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReactStatus>>> GetReactStatus([FromQuery] int statusId)
    {
      return await _context.ReactStatuses.Where(s => s.statusId == statusId).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<ReactStatus>> ReactStatus(ReactStatus reactStatus)
    {
      _context.ReactStatuses.Add(reactStatus);
      await _context.SaveChangesAsync();
      return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> PutReactStatus( [FromQuery] int userId, [FromQuery] int statusId, ReactStatus reactStatus)
    {
      if (userId != reactStatus.userId && statusId != reactStatus.statusId)
      {
        return BadRequest();
      }

      var check = await _context.ReactStatuses.FindAsync(statusId, userId);
      if (check == null)
      {
        return NotFound();
      }

      _context.Entry(reactStatus).State = EntityState.Modified;
        return NoContent();
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteReactStatus( [FromQuery] int statusId, [FromQuery] int userId)
    {
      var react = await _context.ReactStatuses.FindAsync(statusId, userId);
      if (react == null)
      {
        return NotFound();
      }

      _context.ReactStatuses.Remove(react);
      await _context.SaveChangesAsync();
      return NoContent();
    }
  }
}