using System;

namespace Social_network.Models
{
    public class CreateUserModel
    {
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string email { get; set; }
        public string? phone { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string gender { get; set; }
        
    }
}