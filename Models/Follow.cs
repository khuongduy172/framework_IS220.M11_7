using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Social_network.Models
{
    public class Follow
    {
        [Column("user_id")]
        public int userId { get; set; }
        [Column("follower_id")]
        public int followerId { get; set; }


        // [ForeignKey("userId")]
        public UserMxh FollowedUser {get;set;}
        // [ForeignKey("followerId")]
        public UserMxh Follower {get;set;}
    }
}