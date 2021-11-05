using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Social_network.Models
{
    public class Friend
    {
        [Key]
        [Column("user_id")]
        public int userId { get; set; }
        [Column("friend_id")]
        public int friendId { get; set; }
        [ForeignKey("user_id")]
        public UserMxh User {get;set;}
        [ForeignKey("friend_id")]
        public UserMxh userFriend {get;set;}
    }
}