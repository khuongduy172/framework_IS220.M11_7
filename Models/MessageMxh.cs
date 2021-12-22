using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Social_network.Models
{
    public class MessageMxh
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {get; set;}
        [Column("sender_id")]
        public string senderId { get; set; }
        [Column("receiver_id")]
        public string receiverId { get; set; }
        [Column("[content]")]
        public string content { get; set; }
        [Column("creat_at")]
        public DateTime createAt { get; set; }
        [Column("is_read")]
        public bool isRead {get; set;}

        // [ForeignKey("senderId")]
        public UserMxh UserSend { get; set; }
        // [ForeignKey("receiverId")]
        public UserMxh UserReceiver { get; set; }
    }
}