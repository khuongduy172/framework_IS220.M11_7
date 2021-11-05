using Social_network.Models;
using System.Collections.Generic;
using System.Linq;

namespace Social_network.Services
{
    public static class UserService
    {
        static List<User> Users { get; }
        static int nextId = 2;
        static UserService()
        {
            Users = new List<User>
            {
                new User { 
                    Id = 1, 
                    Usesername = "khuongduy17", 
                    Password = "123", 
                    CreatedAt = System.DateTime.UtcNow, 
                    DateOfBirth = System.DateTime.Parse("02/17/2001"), 
                    Email = "19520490@gm.uit.edu.vn",
                    FirstName = "Duy",
                    LastName = "Nguyễn",
                    Phone = "0123456789",
                    Gender = "Nam"
                 }
            };
        }

        public static List<User> GetAll() => Users;

        public static User Get(int id) => Users.FirstOrDefault(p => p.Id == id);

        public static void Add(User user)
        {
            user.Id = nextId++;
            Users.Add(user);
        }

        public static void Delete(int id)
        {
            var user = Get(id);
            if(user is null)
                return;

            Users.Remove(user);
        }

        public static void Update(User user)
        {
            var index = Users.FindIndex(p => p.Id == user.Id);
            if(index == -1)
                return;

            Users[index] = user;
        }
    }
}