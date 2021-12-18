using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Social_network.Models
{
  public class StatusImage
  {
    // [Key]
    [Column("id_image")]
    public string idImage {get; set;}

    [Column("status_id")]
    public int statusId {get; set;}

    [ForeignKey("statusId")]
    public StatusMxh Status { get; set; }
  }
}