using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Social_network.Models
{
    public class Follow
    {
        [Key]
        [Column("user_id")]
        public int userId { get; set; }
        [Key]
        [Column("follow_id")]
        public int followId { get; set; }
        [ForeignKey("user_id")]
        public UserMxh User {get;set;}
        [ForeignKey("follow_id")]
        public UserMxh userFollow{get;set;}
    }
}