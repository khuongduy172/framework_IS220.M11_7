using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Social_network.Models
{
    public class PagePost
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Column("page_id")]
        public int pageId { get; set; }
        [Column("content")]
        public string? content { get; set; }
        [Column("create_at")]
        public DateTime createAt { get; set; }


        [ForeignKey("pageId")]
        public PageMxh Page { get; set; }
        public ICollection<CommentPagePost> CommentPagePosts { get; set; }
        public ICollection<PagePostImage> PagePostImages { get; set; }
        public ICollection<ReactPagePost> ReactPagePosts { get; set; }
    }
}