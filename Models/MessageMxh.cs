using System;
using System.Collections.Generic;

#nullable disable

namespace social_network.Models
{
    public partial class MessageMxh
    {
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual UserMxh Receiver { get; set; }
        public virtual UserMxh Sender { get; set; }
    }
}
