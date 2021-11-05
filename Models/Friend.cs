using System;
using System.Collections.Generic;

#nullable disable

namespace social_network.Models
{
    public partial class Friend
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }

        public virtual UserMxh FriendNavigation { get; set; }
        public virtual UserMxh User { get; set; }
    }
}
