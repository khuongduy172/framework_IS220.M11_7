using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Social_network.Models
{
    public class UserLikePage
    {
        // [Key]
        [Column("page_id")]
        public int pageId { get; set; }
        // [Key]
        [Column("user_id")]
        public int userId { get; set; }


        [ForeignKey("userId")]
        public UserMxh User { get; set; }
        [ForeignKey("pageId")]
        public PageMxh Page { get; set; }
        
    }
}