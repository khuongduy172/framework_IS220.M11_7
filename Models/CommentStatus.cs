using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Social_network.Models
{
  public class CommentStatus
  {
    // [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    // [Key]
    [Column("status_id")]
    public string statusId {get; set;}

    // [Key]
    [Column("user_id")]
    public string userId {get; set;}

    [Column("create_at")]
    public DateTime createAt {get; set;}

    [Column("upadate_at")]
    public DateTime updateAt {get; set;}

    [Column("[content]")]
    public string content {get; set;}


    [ForeignKey("statusId")]
    public StatusMxh Status { get; set; }

    [ForeignKey("userId")]
    public UserMxh User { get; set; }
  }
}