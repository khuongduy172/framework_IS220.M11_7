using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Social_network.Models
{
  public class StatusMxh
  {
    [Key]
    [Column("id")]
    public int statusId {get; set;}

    [Column("owner_id")]
    public int? ownerId {get; set;}

    [Column("[content]")]
    public string? content {get; set;}

    [Column("create_at")]
    public DateTime? createAt {get; set;}

    [Column("upadate_at")]
    public DateTime? updateAt {get; set;}

    [ForeignKey("userId")]
    public UserMxh User { get; set; }

    public ICollection<ReactStatus> ReactStatuses {get; set;}
    public ICollection<StatusImage> StatusImages {get; set;}
    public ICollection<CommentStatus> CommentStatuses {get; set;}
  }
}