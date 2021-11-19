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

  public class CommentStatusController : ControllerBase
  {
    public CommentStatusController(MXHContext context)
    {
      var _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommentStatus>>> GetCommentStatus([FromQuery] int statusId)
    {
      return await _context.CommentStatuses.Where(s => s.statusId == statusId).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<CommentStatus>> CommentStatus(CommentStatus commentStatus)
    {
      _context.CommentStatuses.Add(commentStatus);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> PutReactPagePost( [FromQuery] int userId, [FromQuery] int statusId, CommentStatus commentStatus)
    {
      if (userId != commentStatus.userId && statusId != commentStatus.statusId)
      {
        return BadRequest();
      }

      var check = await _context.CommentStatuses.FindAsync(statusId, userId);
      if (check == null)
      {
        return NotFound();
      }

      _context.Entry(commentStatus).State = EntityState.Modified;
      return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCommentStatus( [FromQuery] int statusId, [FromQuery] int userId)
    {
      var react = await _context.CommentStatuses.FindAsync(statusId, userId);
      if (react == null)
      {
        return NotFound();
      }

      _context.CommentStatuses.Remove(react);
      await _context.SaveChangesAsync();
      return NoContent();
    }
  }
}