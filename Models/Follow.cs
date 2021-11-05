using System;
using System.Collections.Generic;

#nullable disable

namespace social_network.Models
{
    public partial class Follow
    {
        public int UserId { get; set; }
        public int FollowerId { get; set; }

        public virtual UserMxh Follower { get; set; }
        public virtual UserMxh User { get; set; }
    }
}
