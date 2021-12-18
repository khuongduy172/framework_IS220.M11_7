using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Social_network.Models
{
    public class Notification
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Column("fromUID")]
        public int fromId { get; set; }
        [Column("toUID")]
        public int toId { get; set; }
        [Column("content")]
        public string content {get; set;}
        [Column("type_noti")]
        public int type {get; set;}
        [Column("postId")]
        public int postId {get; set;}
        [Column("creat_at")]
        public DateTime createAt { get; set; }
        [Column("update_at")]
        public DateTime updateAt { get; set; }

        public UserMxh UserFrom {get;set;}
        public UserMxh UserTo {get;set;}
    }
}