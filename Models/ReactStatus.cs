using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Social_network.Models
{
  public class ReactStatus
  {
    // [Key]
    [Column("status_id")]
    public string statusId {get; set;}

    // [Key]
    [Column("user_id")]
    public string userId {get; set;}

    [Column("type_react")]
    public string reactType {get; set;}

    [ForeignKey("statusId")]
    public StatusMxh Status { get; set; }

    [ForeignKey("userId")]
    public UserMxh User { get; set; }
  }
}