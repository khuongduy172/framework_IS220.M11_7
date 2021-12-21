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
  public class StatusImageController : ControllerBase
  {
    private readonly MXHContext _context;
    public StatusImageController(MXHContext context)
    {
      var _context = context;
    }

    [HttpGet]
    public IQueryable GetStatusImage([FromQuery] string statusId)
    {
      var query = from i in _context.StatusImages
                  where i.statusId == statusId
                  select i;
      return query;
    }

    [HttpPost]
    public async Task<IActionResult> StatusImage(StatusImage statusImage)
    {
        _context.StatusImages.Add(statusImage);
        await _context.SaveChangesAsync();
        return Ok(statusImage);
    }

    [HttpPut]
    public async Task<IActionResult> PutStatusImage(  [FromQuery] string statusId, StatusImage statusImage)
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
    public async Task<IActionResult> DeleteStatusImage( [FromQuery] string statusId, string image)
    {
      var react = await _context.StatusImages.FindAsync(image, statusId);
            if (react == null)
            {
                return NotFound();
            }

            // _context.StatusImages.Remove(react);
            // await _context.SaveChangesAsync();

            // return NoContent();
            return Ok(react);
    }
  }
}