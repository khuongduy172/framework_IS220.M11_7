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
  public class CommentStatusController : ControllerBase
  {
    private readonly MXHContext _context;
    public CommentStatusController(MXHContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCommentStatus(string statusId)
    {
      var query = await (from c in _context.CommentStatuses
                  where c.statusId == statusId
                  select c).ToListAsync();
      List<object> result = new List<object>();
      foreach (var item in query)
      {
        var user = (from u in _context.UserMxhs
                    where u.id == item.userId
                    select u).FirstOrDefault();
        result.Add(new {
          item.content,
          item.createAt,
          item.id,
          item.statusId,
          item.updateAt,
          item.userId,
          user.avatar,
          username = user.lastName + " " + user.firstName,
        });
      }
      return Ok(result);
    }

    // [HttpPut]
    // public async Task<IActionResult> PutReactPagePost( [FromQuery] int userId, [FromQuery] int statusId, CommentStatus commentStatus)
    // {
    //   if (userId != commentStatus.userId && statusId != commentStatus.statusId)
    //   {
    //     return BadRequest();
    //   }

    //   var check = await _context.CommentStatuses.FindAsync(statusId, userId);
    //   if (check == null)
    //   {
    //     return NotFound();
    //   }

    //   _context.Entry(commentStatus).State = EntityState.Modified;
    //   return NoContent();
    // }

    // [HttpDelete]
    // public async Task<IActionResult> DeleteCommentStatus( [FromQuery] int statusId, [FromQuery] int userId)
    // {
    //   var react = await _context.CommentStatuses.FindAsync(statusId, userId);
    //   if (react == null)
    //   {
    //     return NotFound();
    //   }

    //   _context.CommentStatuses.Remove(react);
    //   await _context.SaveChangesAsync();
    //   return NoContent();
    // }
  }
}