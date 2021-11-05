using System;
using System.Collections.Generic;

#nullable disable

namespace social_network.Models
{
    public partial class CommentStatus
    {
        public int Id { get; set; }
        public int? StatusId { get; set; }
        public int? UserId { get; set; }
        public string Content { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual StatusMxh Status { get; set; }
        public virtual UserMxh User { get; set; }
    }
}
