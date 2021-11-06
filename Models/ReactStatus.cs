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

    [Column("react_type")]
    public string? reactType {get; set;}

    [ForeignKey("statusId")]
    public StatusMxh Status { get; set; }

    [ForeignKey("userId")]
    public UserMxh User { get; set; }
  }
}