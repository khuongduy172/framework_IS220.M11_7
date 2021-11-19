using System;
using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata;
// using System.Configuration;
using Social_network.Models;

namespace Social_network.Data
{
    public class MXHContext : DbContext 
    {
        public MXHContext() 
        {

        }
        public MXHContext(DbContextOptions<MXHContext> options) : base(options)
        {

        }

        public DbSet<UserLikePage> UserLikePages { get; set; }
        public DbSet<PagePostImage> PagePostImages { get; set; }
        public DbSet<StatusMxh> StatusMxhs { get; set; }
        public DbSet<ReactStatus> ReactStatuses { get; set; }
        public DbSet<CommentStatus> CommentStatuses { get; set; }
        public DbSet<StatuImages> StatusImages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<UserLikePage>().ToTable("User_like_page");
            modelBuilder.Entity<PagePostImage>().ToTable("Page_post_image");
        }
    }
}