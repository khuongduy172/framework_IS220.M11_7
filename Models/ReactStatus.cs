using System;
using System.Collections.Generic;

#nullable disable

namespace social_network.Models
{
    public partial class ReactStatus
    {
        public int Id { get; set; }
        public int? StatusId { get; set; }
        public string TypeReact { get; set; }
        public int? UserId { get; set; }

        public virtual StatusMxh Status { get; set; }
        public virtual UserMxh User { get; set; }
    }
}
