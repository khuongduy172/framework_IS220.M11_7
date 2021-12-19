using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Social_network.Models
{
    public class UserLikePage
    {
        // [Key]
        [Column("page_id")]
        public string pageId { get; set; }
        // [Key]
        [Column("user_id")]
        public string userId { get; set; }


        [ForeignKey("userId")]
        public UserMxh User { get; set; }
        [ForeignKey("pageId")]
        public PageMxh Page { get; set; }
        
    }
}