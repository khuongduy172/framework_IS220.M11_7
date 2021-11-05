using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Social_network.Models
{
    public class PagePostImage
    {
        [Key]
        [Column("id_image")]
        public string imageId { get; set; }
        [Column("post_id")]
        public int postId { get; set; }
        
        [ForeignKey("postId")]
        public PagePost PagePost { get; set; }
        
    }
}