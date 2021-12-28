using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_network.Data;
using Microsoft.AspNetCore.Authorization;
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
    [Route("get-by-id")]
    public async Task<ActionResult<IEnumerable<StatusMxh>>> GetStatusMxh([FromQuery] string statusId)
    {
      // var friendId = from f in _context.Friends
      return await _context.StatusMxhs.Where(s => s.statusId == statusId).ToListAsync();
    }

    [HttpGet]
    [Route("get-all-by-userid")]
    public async Task<IActionResult> GetAllByUserId (string userId) 
    {
      var query = await (from s in _context.StatusMxhs
                  join u in _context.UserMxhs on s.ownerId equals u.id
                  where s.ownerId == userId
                  select new {
                    content = s.content,
                    createAt = s.createAt,
                    statusId = s.statusId,
                    ownerId = s.ownerId,
                    updateAt = s.updateAt,
                  }).ToListAsync();
      List<object> result = new List<object>();
      foreach (var item in query)
      {
          var images = await (from i in _context.StatusImages
                      where i.statusId == item.statusId
                      select i).ToListAsync();
          var user = (from u in _context.UserMxhs
                    where u.id == item.ownerId
                    select u).FirstOrDefault();
          result.Add(new {
              content = item.content,
              createAt = item.createAt,
              statusId = item.statusId,
              ownerId = item.ownerId,
              updateAt = item.updateAt,
              images = images,
              user = user,
          });
      }
      return Ok(result);
    }

    [HttpGet]
    [Route("get-all-by-userid2")]
    public async Task<IActionResult> GetAllByUserId2 (string userId) 
    {
      var query = await (from s in _context.StatusMxhs
                  join u in _context.UserMxhs on s.ownerId equals u.id
                  where s.ownerId == userId
                  select new {
                    content = s.content,
                    createAt = s.createAt,
                    statusId = s.statusId,
                    ownerId = s.ownerId,
                    updateAt = s.updateAt,
                  }).ToListAsync();
      List<object> result = new List<object>();
      foreach (var item in query)
      {
          var images = await (from i in _context.StatusImages
                      where i.statusId == item.statusId
                      select i.url).ToListAsync();
          var user = (from u in _context.UserMxhs
                    where u.id == item.ownerId
                    select u).FirstOrDefault();
          result.Add(new {
              content = item.content,
              createAt = item.createAt,
              statusId = item.statusId,
              ownerId = item.ownerId,
              updateAt = item.updateAt,
              images = images,
              user = user,
          });
      }
      return Ok(result);
    }

    // [HttpGet]
    // [Route("get-all")]
    // public IQueryable GetAll()
    // {
    //   var query = from s in _context.StatusMxhs
    //               select s;
    //   return query;
    // }

    [HttpGet]
    [Route("get-random-status")]
    [Authorize]
    public IQueryable GetRandomStatus ()
    {
        var me = HttpContext.User.Claims.Single(u => u.Type == "Id").Value;
        var idList = ((from fl in _context.Follows
                      where fl.userId == me
                      select fl.followerId)
                      .Union(from fr in _context.Friends
                              where fr.userId == me
                              select fr.friendId)).Union(from u in _context.UserMxhs
                                                          where u.id == me
                                                          select u.id);
        var query = from s in _context.StatusMxhs
                    where idList.Contains(s.ownerId)
                    orderby s.createAt descending
                    select s;
        return query;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> StatusMxh([FromBody]CreateStatusModel status)
    {
      try {
        var me = HttpContext.User.Claims.Single(u => u.Type == "Id").Value;
        StatusMxh newStatus = new StatusMxh();
        newStatus.statusId = Guid.NewGuid().ToString();
        newStatus.content = status.content;
        newStatus.createAt = DateTime.Now;
        newStatus.ownerId = me;
        newStatus.updateAt = DateTime.Now;

        _context.StatusMxhs.Add(newStatus);
        await _context.SaveChangesAsync();
        return Ok(newStatus);
      } catch {
        return BadRequest();
      }
    }

    [HttpPut]
    public async Task<IActionResult> PutStatusMxh( [FromQuery] string ownerId, [FromQuery] string statusId, StatusMxh statusMxh)
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