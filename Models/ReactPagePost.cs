using System;
using System.Collections.Generic;

#nullable disable

namespace social_network.Models
{
    public partial class ReactPagePost
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public string TypeReact { get; set; }
        public int? UserId { get; set; }

        public virtual PagePost Post { get; set; }
        public virtual UserMxh User { get; set; }
    }
}
