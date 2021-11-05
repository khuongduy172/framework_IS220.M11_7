using System;
using System.Collections.Generic;

#nullable disable

namespace social_network.Models
{
    public partial class PageMxh
    {
        public PageMxh()
        {
            PagePosts = new HashSet<PagePost>();
            UserLikePages = new HashSet<UserLikePage>();
        }

        public int Id { get; set; }
        public int? OwnerId { get; set; }
        public string DescriptionMxh { get; set; }
        public string NamePage { get; set; }
        public string Avatar { get; set; }
        public string CoverImage { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual UserMxh Owner { get; set; }
        public virtual ICollection<PagePost> PagePosts { get; set; }
        public virtual ICollection<UserLikePage> UserLikePages { get; set; }
    }
}
