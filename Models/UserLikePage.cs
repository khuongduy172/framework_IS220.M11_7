using System;
using System.Collections.Generic;

#nullable disable

namespace social_network.Models
{
    public partial class UserLikePage
    {
        public int PageId { get; set; }
        public int UserId { get; set; }

        public virtual PageMxh Page { get; set; }
        public virtual UserMxh User { get; set; }
    }
}
