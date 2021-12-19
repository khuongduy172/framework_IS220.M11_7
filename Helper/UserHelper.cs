using System;
using Microsoft.EntityFrameworkCore;
using Social_network.Models;
using Social_network.Data;
using System.Threading.Tasks;

namespace Social_network.Helper
{
    public class UserHelper
    {
        private readonly MXHContext _context;
        public UserHelper(MXHContext context) 
        {
            _context = context;
        }
        public async Task<UserMxh> GetUserById (int id) 
        {
            var user = await _context.UserMxhs.FindAsync(id);

            return user;
        }
    }
}