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

        // [HttpPut]
        // public async Task<IActionResult> PutStatusImage(  [FromQuery] string statusId, string url)
        // {
        //     var query = (from simg in _context.StatusImages
        //                 where simg.statusId == statusId
        //                 select simg).FirstOrDefault();
        //     query.content = content;
        //     query.createAt = DateTime.Now;
        //     query.updateAt = DateTime.Now;

        //     await _context.SaveChangesAsync();
        //     return Ok(query);
        // }

        [HttpDelete]
        public async Task<IActionResult> DeleteStatusImage( [FromQuery] string statusId)
        {
            var image = await (from i in _context.StatusImages
                                where i.statusId == statusId
                                select i).ToListAsync();
            foreach (var item in image)
            {
                var imageItem = (from it in image
                                select it).FirstOrDefault();
                _context.StatusImages.Remove(imageItem);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }
    }
}
