using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_network.Data;
using Social_network.Models;


namespace Social_network.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusImageController : ControllerBase
    {
        private readonly MXHContext _context;

        public StatusImageController(MXHContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetStatusImage([FromQuery] string statusId)
        {
            var query = await (from i in _context.StatusImages
                         where i.statusId == statusId
                         select i).ToListAsync();
            List<object> result = new List<object>();
            foreach (var item in query) {
                result.Add(item);
            }
            return Ok(result);
        }
        
        [HttpGet]
        [Route("get-all")]
        public IQueryable GetAllStatusImage()
        {
            var query = from i in _context.StatusImages
                         select i;
            return query;
        }

        [HttpPost]
        public async Task<IActionResult> StatusImage(StatusImage statusImage)
        {
            try
            {
                StatusImage newStatusImage = new StatusImage();
                newStatusImage.statusId = statusImage.statusId;
                newStatusImage.url = statusImage.url;

                _context.StatusImages.Add(newStatusImage);
                await _context.SaveChangesAsync();
                return Ok(newStatusImage);
            }
            catch
            {
                return BadRequest();
            }
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
