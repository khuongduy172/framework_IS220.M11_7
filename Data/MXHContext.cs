using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
using social_network.Models;

#nullable disable

namespace social_network.Data
{
    public partial class MXHContext : DbContext
    {
        public MXHContext()
        {
        }

        public MXHContext(DbContextOptions<MXHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CommentPagePost> CommentPagePosts { get; set; }
        public virtual DbSet<CommentStatus> CommentStatuses { get; set; }
        public virtual DbSet<Follow> Follows { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<MessageMxh> MessageMxhs { get; set; }
        public virtual DbSet<PageMxh> PageMxhs { get; set; }
        public virtual DbSet<PagePost> PagePosts { get; set; }
        public virtual DbSet<PagePostImage> PagePostImages { get; set; }
        public virtual DbSet<ReactPagePost> ReactPagePosts { get; set; }
        public virtual DbSet<ReactStatus> ReactStatuses { get; set; }
        public virtual DbSet<StatusImage> StatusImages { get; set; }
        public virtual DbSet<StatusMxh> StatusMxhs { get; set; }
        public virtual DbSet<UserLikePage> UserLikePages { get; set; }
        public virtual DbSet<UserMxh> UserMxhs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CommentPagePost>(entity =>
            {
                entity.ToTable("Comment_page_post");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasColumnName("content");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("update_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.CommentPagePosts)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_Comment_page_post_post_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommentPagePosts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Comment_page_post_userId");
            });

            modelBuilder.Entity<CommentStatus>(entity =>
            {
                entity.ToTable("Comment_status");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasColumnName("content");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("update_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.CommentStatuses)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Comment_status_status_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommentStatuses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Comment_status_userId");
            });

            modelBuilder.Entity<Follow>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FollowerId });

                entity.ToTable("Follow");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.FollowerId).HasColumnName("follower_id");

                entity.HasOne(d => d.Follower)
                    .WithMany(p => p.FollowFollowers)
                    .HasForeignKey(d => d.FollowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_FL");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FollowUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FL_USER");
            });

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FriendId });

                entity.ToTable("Friend");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.FriendId).HasColumnName("friend_id");

                entity.HasOne(d => d.FriendNavigation)
                    .WithMany(p => p.FriendFriendNavigations)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_FR");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FriendUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FR_USER");
            });

            modelBuilder.Entity<MessageMxh>(entity =>
            {
                entity.ToTable("Message_MXH");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasColumnName("content");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");

                entity.Property(e => e.SenderId).HasColumnName("sender_id");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.MessageMxhReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .HasConstraintName("FK_Message_MXH_receiver_id");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.MessageMxhSenders)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK_Message_MXH_sender_id");
            });

            modelBuilder.Entity<PageMxh>(entity =>
            {
                entity.ToTable("Page_MXH");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(225)
                    .HasColumnName("avatar");

                entity.Property(e => e.CoverImage)
                    .HasMaxLength(225)
                    .HasColumnName("cover_image");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.DescriptionMxh)
                    .HasMaxLength(225)
                    .HasColumnName("description_MXH");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.NamePage)
                    .HasMaxLength(225)
                    .HasColumnName("name_page");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("update_at");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.PageMxhs)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Page_owner_id");
            });

            modelBuilder.Entity<PagePost>(entity =>
            {
                entity.ToTable("Page_post");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasColumnName("content");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.PageId).HasColumnName("page_id");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.PagePosts)
                    .HasForeignKey(d => d.PageId)
                    .HasConstraintName("FK_Page_post_page_id");
            });

            modelBuilder.Entity<PagePostImage>(entity =>
            {
                entity.HasKey(e => e.IdImage);

                entity.ToTable("Page_post_image");

                entity.Property(e => e.IdImage)
                    .HasMaxLength(255)
                    .HasColumnName("id_image");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PagePostImages)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_page_image_post_id");
            });

            modelBuilder.Entity<ReactPagePost>(entity =>
            {
                entity.ToTable("React_page_post");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.TypeReact)
                    .HasMaxLength(100)
                    .HasColumnName("type_react");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.ReactPagePosts)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_Reate_page_post_post_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReactPagePosts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_user_react_page_post");
            });

            modelBuilder.Entity<ReactStatus>(entity =>
            {
                entity.ToTable("React_status");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.TypeReact)
                    .HasMaxLength(100)
                    .HasColumnName("type_react");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ReactStatuses)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_React_status_status_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReactStatuses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_React_status_userId");
            });

            modelBuilder.Entity<StatusImage>(entity =>
            {
                entity.HasKey(e => e.IdImage);

                entity.ToTable("Status_image");

                entity.Property(e => e.IdImage)
                    .HasMaxLength(255)
                    .HasColumnName("id_image");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.StatusImages)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Status_image_status_id");
            });

            modelBuilder.Entity<StatusMxh>(entity =>
            {
                entity.ToTable("Status_MXH");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasColumnName("content");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("update_at");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.StatusMxhs)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Status_owner_id");
            });

            modelBuilder.Entity<UserLikePage>(entity =>
            {
                entity.HasKey(e => new { e.PageId, e.UserId });

                entity.ToTable("User_like_page");

                entity.Property(e => e.PageId).HasColumnName("page_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.UserLikePages)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_like_page_page_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLikePages)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_like_page_userId");
            });

            modelBuilder.Entity<UserMxh>(entity =>
            {
                entity.ToTable("User_MXH");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(225)
                    .HasColumnName("avatar");

                entity.Property(e => e.CoverImage)
                    .HasMaxLength(225)
                    .HasColumnName("cover_image");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.DeleteAt)
                    .HasColumnType("datetime")
                    .HasColumnName("delete_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(225)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(225)
                    .HasColumnName("last_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("user_password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
