using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;


namespace Social_network.Models
{
  public class StatusImage
  {
    // [Key]
    [Column("id_image")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idImage {get; set;}

    [Column("status_id")]
    public string statusId {get; set;}
    [Column("url")]
    public string url {get; set;}

    [ForeignKey("statusId")]
    public StatusMxh Status { get; set; }
  }
}