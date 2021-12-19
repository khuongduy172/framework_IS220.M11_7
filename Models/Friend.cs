using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Social_network.Models
{
    public class Friend
    {
        [Column("user_id")]
        public string userId { get; set; }
        [Column("friend_id")]
        public string friendId { get; set; }


        // [ForeignKey("userId")]
        public UserMxh User {get;set;}
        // [ForeignKey("friendId")]
        public UserMxh userFriend {get;set;}
    }
}