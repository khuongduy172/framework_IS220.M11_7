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
        public string fromId { get; set; }
        [Column("toUID")]
        public string toId { get; set; }
        [Column("content")]
        public string content {get; set;}
        [Column("type_noti")]
        public int type {get; set;}
        [Column("postId")]
        public string postId {get; set;}
        [Column("create_at")]
        public DateTime createAt { get; set; }
        [Column("update_at")]
        public DateTime updateAt { get; set; }
        [Column("is_read")]
        public bool isRead {get; set;}
        public UserMxh UserFrom {get;set;}
        public UserMxh UserTo {get;set;}
    }
}