using System;
using System.Collections.Generic;

#nullable disable

namespace social_network.Models
{
    public partial class StatusMxh
    {
        public StatusMxh()
        {
            CommentStatuses = new HashSet<CommentStatus>();
            ReactStatuses = new HashSet<ReactStatus>();
            StatusImages = new HashSet<StatusImage>();
        }

        public int Id { get; set; }
        public int? OwnerId { get; set; }
        public string Content { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual UserMxh Owner { get; set; }
        public virtual ICollection<CommentStatus> CommentStatuses { get; set; }
        public virtual ICollection<ReactStatus> ReactStatuses { get; set; }
        public virtual ICollection<StatusImage> StatusImages { get; set; }
    }
}
