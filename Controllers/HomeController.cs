using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using social_network.Data;
using social_network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace social_network.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public readonly ApplicationDbContext _context;
        public readonly UserManager<AppUser> _userManager;
        public HomeController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = currentUser.UserName;
            }
            var messages = await _context.Messages.ToListAsync();
            return View();
        } 

        public async Task<IActionResult> Create(Message message)
        {
            if (ModelState.IsValid)
            {
                message.UserName = User.Identity.Name;
                var sender = await _userManager.GetUserAsync(User);
                message.UserID = sender.Id;
                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return Error();
        }

        private IActionResult Error()
        {
            throw new NotImplementedException();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
