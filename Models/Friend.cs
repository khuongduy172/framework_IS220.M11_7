using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Social_network.Models
{
    public class Friend
    {
        [Column("user_id")]
        public int userId { get; set; }
        [Column("friend_id")]
        public int friendId { get; set; }


        // [ForeignKey("userId")]
        public UserMxh User {get;set;}
        // [ForeignKey("friendId")]
        public UserMxh userFriend {get;set;}
    }
}