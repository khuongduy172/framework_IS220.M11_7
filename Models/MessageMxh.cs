using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Social_network.Models
{
    public class MessageMxh
    {
        [Key]
        [Column("sender_id")]
        public int senderId { get; set; }
        [Key]
        [Column("receiver_id")]
        public int receiverId { get; set; }
        [Column("[content]")]
        public string? content { get; set; }
        [Column("creat_at")]
        public DateTime? createAt { get; set; } 
        [ForeignKey("sender_id")]
        public UserMxh User {get;set;}
        [ForeignKey("receiver_id")]
        public UserMxh userReceiver {get;set;}
    }
}