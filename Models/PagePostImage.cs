using System;
using System.Collections.Generic;

#nullable disable

namespace social_network.Models
{
    public partial class PagePostImage
    {
        public string IdImage { get; set; }
        public int? PostId { get; set; }

        public virtual PagePost Post { get; set; }
    }
}
