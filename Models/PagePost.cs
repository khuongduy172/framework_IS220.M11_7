using System;
using System.Collections.Generic;

#nullable disable

namespace social_network.Models
{
    public partial class PagePost
    {
        public PagePost()
        {
            CommentPagePosts = new HashSet<CommentPagePost>();
            PagePostImages = new HashSet<PagePostImage>();
            ReactPagePosts = new HashSet<ReactPagePost>();
        }

        public int Id { get; set; }
        public int? PageId { get; set; }
        public string Content { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual PageMxh Page { get; set; }
        public virtual ICollection<CommentPagePost> CommentPagePosts { get; set; }
        public virtual ICollection<PagePostImage> PagePostImages { get; set; }
        public virtual ICollection<ReactPagePost> ReactPagePosts { get; set; }
    }
}
