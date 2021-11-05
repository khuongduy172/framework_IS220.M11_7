using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Social_network.Models
{
  public class ReactStatus
  {
    [Key]
    [Column("status_id")]
    public int statusId {get; set;}

    [Key]
    [Column("user_id")]
    public int userId {get; set;}

    [Column("create_at")]
    public DateTime? createAt {get; set;}

    [Column("upadate_at")]
    public DateTime? updateAt {get; set;}

    [Column("[content]")]
    public string? content {get; set;}

    [ForeignKey("statusId")]
    public StatusMxh Status { get; set; }

    [ForeignKey("userId")]
    public UserMxh User { get; set; }
  }
}