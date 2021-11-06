using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Social_network.Models
{
    public class ReactPagePost
    {
        [Key]
        [Column("post_id")]
        public int postId { get; set; }
        [Key]
        [Column("user_id")]
        public int userId { get; set; }
        [Column("type_react")]
        public string? typeReact { get; set; }

        [ForeignKey("userId")]
        public UserMxh User { get; set; }

        [ForeignKey("postId")]
        public PagePost Page { get; set; }
    }
}