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

        public DbSet<CommentPagePost> CommentPagePosts { get; set; }
        public DbSet<CommentStatus> CommentStatuses { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<MessageMxh> MessageMxhs { get; set; }
        public DbSet<PageMxh> PageMxhs { get; set; }
        public DbSet<PagePost> PagePosts { get; set; }
        public DbSet<PagePostImage> PagePostImages { get; set; }
        public DbSet<ReactPagePost> ReactPagePosts { get; set; }
        public DbSet<ReactStatus> ReactStatuses { get; set; }
        public DbSet<StatusMxh> StatusMxhs { get; set; }
        public DbSet<StatusImage> StatusImages { get; set; }
        public DbSet<UserLikePage> UserLikePages { get; set; }
        public DbSet<UserMxh> UserMxhs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<CommentPagePost>().ToTable("Comment_page_post").HasKey(c => new { c.id, c.postId, c.userId});
            modelBuilder.Entity<CommentStatus>().ToTable("Comment_status").HasKey(c => new {c.id, c.statusId, c.userId});
            modelBuilder.Entity<Follow>(entity => {
                entity.ToTable("Follow");
                entity.HasKey(c => new {c.userId, c.followerId});

                entity.HasOne(e => e.FollowedUser)
                        .WithMany(e => e.Followers)
                        .HasForeignKey(e => e.userId);
                
                entity.HasOne(e => e.Follower)
                        .WithMany(e => e.FollowedUsers)
                        .HasForeignKey(e => e.followerId);

            });

            modelBuilder.Entity<Friend>(entity => {
                entity.ToTable("Friend");
                entity.HasKey(c => new {c.friendId, c.userId});

                entity.HasOne(e => e.User)
                        .WithMany(e => e.FriendsOfUsers)
                        .HasForeignKey(e => e.userId);
                entity.HasOne(e => e.userFriend)
                        .WithMany(e => e.UserHasFriends)
                        .HasForeignKey(e => e.friendId);
            });
            modelBuilder.Entity<MessageMxh>(entity => {
                entity.ToTable("Message_MXH");
                entity.HasKey(c => new {c.id, c.receiverId, c.senderId});

                entity.HasOne(e => e.UserReceiver)
                        .WithMany(e => e.MessagesFrom)
                        .HasForeignKey(e => e.receiverId);
                entity.HasOne(e => e.UserSend)
                        .WithMany(e => e.MessagesTo)
                        .HasForeignKey(e => e.senderId);
            });
            modelBuilder.Entity<Notification>(entity => {
                entity.ToTable("Notification_MXH");
                entity.HasKey(c => c.id);

                entity.HasOne(e => e.UserFrom)
                        .WithMany(e => e.NotiTo)
                        .HasForeignKey(e => e.fromId);
                entity.HasOne(e => e.UserTo)
                        .WithMany(e => e.NotiFrom)
                        .HasForeignKey(e => e.toId);
            });
            modelBuilder.Entity<PageMxh>().ToTable("Page_MXH").HasKey(c => c.id);
            modelBuilder.Entity<PagePost>().ToTable("Page_post").HasKey(c => c.id);
            modelBuilder.Entity<PagePostImage>().ToTable("Page_post_image").HasKey(c => c.imageId);
            modelBuilder.Entity<ReactPagePost>().ToTable("React_page_post").HasKey(c => new {c.postId, c.userId});
            modelBuilder.Entity<ReactStatus>().ToTable("React_status").HasKey(c => new {c.statusId, c.userId});
            modelBuilder.Entity<StatusImage>().ToTable("Status_image").HasKey(c => c.idImage);
            modelBuilder.Entity<StatusMxh>().ToTable("Status_MXH").HasKey(c => c.statusId);
            modelBuilder.Entity<UserLikePage>().ToTable("User_like_page").HasKey(c => new {c.pageId, c.userId});
            modelBuilder.Entity<UserMxh>().ToTable("User_MXH").HasKey(c => c.id);
        }
        
    }
}