using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Social_network.Models
{
  public class StatusMxh
  {
    // [Key]
    [Column("id")]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string statusId {get; set;}

    [Column("owner_id")]
    public string ownerId {get; set;}

    [Column("content")]
    public string content {get; set;}

    [Column("create_at")]
    public DateTime createAt {get; set;}

    [Column("update_at")]
    public DateTime updateAt {get; set;}

    [ForeignKey("ownerId")]
    public UserMxh User { get; set; }

    public ICollection<ReactStatus> ReactStatuses {get; set;}
    public ICollection<StatusImage> StatusImages {get; set;}
    public ICollection<CommentStatus> CommentStatuses {get; set;}
  }
}