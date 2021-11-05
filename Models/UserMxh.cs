using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Social_network.Models
{
    public class UserMxh
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("username")]
        public string userName { get; set; }
        [Column("user_password")]
        public string userPassword { get; set; }
        [Column("email")]
        public string email { get; set; }
        [Column("phone")]
        public string phone { get; set; }
        [Column("first_name")]
        public string firstName { get; set; }
        [Column("last_name")]
        public string lastName { get; set; }
        [Column("avatar")]
        public string avatar { get; set; }
        [Column("cover_image")]
        public string coverImage { get; set; }
        [Column("date_of_birth")]
        public DateTime dateOfBirth { get; set; }
        [Column("gender")]
        public string gender { get; set; }
        [Column("is_deleted")]
        public bool isDeleted { get; set; }
        [Column("delete_at")]
        public DateTime deletedAt { get; set; }
        [Column("create_at")]
        public DateTime createdAt { get; set; }
        
    }
}