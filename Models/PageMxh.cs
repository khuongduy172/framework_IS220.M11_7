using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

#nullable disable

namespace Social_network.Models
{
    public class PageMxh
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Column("owner_id")]
        public int ownerId { get; set; }
        [Column("description_MXH")]
        public string? description { get; set; }
        [Column("name_page")]
        public string namePage { get; set; }
        [Column("avatar")]
        public string? avatar { get; set; }
        [Column("cover_image")]
        public string? coverImage { get; set; }
        [Column("create_at")]
        public DateTime createAt { get; set; }
        [Column("update_at")]
        public DateTime updateAt { get; set; }
        [Column("is_deleted")]
        public Boolean? isDeleted { get; set; }


        [ForeignKey("ownerId")]
        public UserMxh User { get; set; }
        public ICollection<PagePost> PagePosts { get; set; }
        public ICollection<UserLikePage> UserLikePages { get; set; }
    }
}