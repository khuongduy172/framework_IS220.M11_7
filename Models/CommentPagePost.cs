using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Social_network.Models
{
    public class CommentPagePost
    {
        [Key]
        [Column("post_id")]
        public int postId { get; set; }
        [Key]
        [Column("user_id")]
        public int userId { get; set; }
        [Column("content")]
        public string content { get; set; }
        [Column("create_at")]
        public DateTime createAt { get; set; }
        [Column("update_at")]
        public DateTime updateAt { get; set; }


        [ForeignKey("postId")]
        public PagePost Page { get; set; }
        [ForeignKey("userId")]
        public UserMxh User { get; set; }
        
    }
}