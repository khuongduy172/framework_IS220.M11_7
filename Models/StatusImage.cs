using System;
using System.Collections.Generic;

#nullable disable

namespace social_network.Models
{
    public partial class StatusImage
    {
        public string IdImage { get; set; }
        public int? StatusId { get; set; }

        public virtual StatusMxh Status { get; set; }
    }
}
