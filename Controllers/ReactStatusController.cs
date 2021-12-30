using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_network.Data;
using Social_network.Models;
using Microsoft.AspNetCore.Authorization;

namespace Social_network.Controllers 
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReactStatusController : ControllerBase
  {
    private readonly MXHContext _context;
    public ReactStatusController(MXHContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetReactStatus([FromQuery] string statusId)
    {
      var react = await (from r in _context.ReactStatuses
                    where r.statusId == statusId
                    select r).ToListAsync();
      List<object> result = new List<object>();
      foreach( var item in react)
      {
        var user = (from u in _context.UserMxhs
                    where u.id == item.userId
                    select u).FirstOrDefault();
        result.Add(new {
          item.reactType,
          item.statusId,
          item.userId,
          user.firstName,
          user.lastName,
        });
      }
      
      return Ok(result);
    }

    [Authorize]
    [HttpGet]
    [Route("check-react")]
    public bool CheckReact (string statusId)
    {
      var me = HttpContext.User.Claims.Single(u => u.Type == "Id").Value;
      var query = (from r in _context.ReactStatuses
                  where r.userId == me && r.statusId == statusId
                  select r.userId).Contains(me);
      return query;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> React (string type, string statusId)
    {
      var me = HttpContext.User.Claims.Single(u => u.Type == "Id").Value;
      var exist = (from r in _context.ReactStatuses
                  where r.statusId == statusId && r.userId == me
                  select r).FirstOrDefault();
      if (exist != null) 
      {
        _context.ReactStatuses.Remove(exist);
        await _context.SaveChangesAsync();
        if (type != exist.reactType) 
        {
          var newReact = new ReactStatus();
          newReact.reactType = type;
          newReact.statusId = statusId;
          newReact.userId = me;
          _context.ReactStatuses.Add(newReact);
          await _context.SaveChangesAsync();
      }
      }
      if (exist is null) 
      {
        var newReact = new ReactStatus();
        newReact.reactType = type;
        newReact.statusId = statusId;
        newReact.userId = me;
        _context.ReactStatuses.Add(newReact);
        await _context.SaveChangesAsync();
      }
      return NoContent();
    }

    // [HttpPost]
    // public async Task<ActionResult<ReactStatus>> ReactStatus(ReactStatus reactStatus)
    // {
    //   _context.ReactStatuses.Add(reactStatus);
    //   await _context.SaveChangesAsync();
    //   return NoContent();
    // }

    // [HttpPut]
    // public async Task<IActionResult> PutReactStatus( [FromQuery] string userId, [FromQuery] string statusId, ReactStatus reactStatus)
    // {
    //   if (userId != reactStatus.userId && statusId != reactStatus.statusId)
    //   {
    //     return BadRequest();
    //   }

    //   var check = await _context.ReactStatuses.FindAsync(statusId, userId);
    //   if (check == null)
    //   {
    //     return NotFound();
    //   }

    //   _context.Entry(reactStatus).State = EntityState.Modified;
    //     return NoContent();
    // }


    // [HttpDelete]
    // public async Task<IActionResult> DeleteReactStatus( [FromQuery] int statusId, [FromQuery] int userId)
    // {
    //   var react = await _context.ReactStatuses.FindAsync(statusId, userId);
    //   if (react == null)
    //   {
    //     return NotFound();
    //   }

    //   _context.ReactStatuses.Remove(react);
    //   await _context.SaveChangesAsync();
    //   return NoContent();
    // }
  }
}