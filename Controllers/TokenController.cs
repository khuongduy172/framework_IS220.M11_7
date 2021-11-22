using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Social_network.Models;
using Social_network.Data;
 
namespace Social_network.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly MXHContext _context;
 
        public TokenController(IConfiguration config, MXHContext context)
        {
            _configuration = config;
            _context = context;
        }
 
        [HttpPost]
        public async Task<IActionResult> Post( [FromBody] Login login)
        {
 
            if (login.username != null && login.password != null)
            {
                var user = await GetUser(login.username, login.password);
 
                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.id.ToString()),
                    new Claim("FirstName", user.firstName),
                    new Claim("LastName", user.lastName),
                    new Claim("UserName", user.userName),
                    new Claim("Email", user.email)
                   };
 
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
 
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
 
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
 
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
 
        private async Task<UserMxh> GetUser(string username, string password)
        {
            return await _context.UserMxhs.FirstOrDefaultAsync(u => u.userName == username && u.userPassword == password);
        }
    }
}