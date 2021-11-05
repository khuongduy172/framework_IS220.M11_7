using System;
using System.Collections.Generic;

#nullable disable

namespace social_network.Models
{
    public partial class UserMxh
    {
        public UserMxh()
        {
            CommentPagePosts = new HashSet<CommentPagePost>();
            CommentStatuses = new HashSet<CommentStatus>();
            FollowFollowers = new HashSet<Follow>();
            FollowUsers = new HashSet<Follow>();
            FriendFriendNavigations = new HashSet<Friend>();
            FriendUsers = new HashSet<Friend>();
            MessageMxhReceivers = new HashSet<MessageMxh>();
            MessageMxhSenders = new HashSet<MessageMxh>();
            PageMxhs = new HashSet<PageMxh>();
            ReactPagePosts = new HashSet<ReactPagePost>();
            ReactStatuses = new HashSet<ReactStatus>();
            StatusMxhs = new HashSet<StatusMxh>();
            UserLikePages = new HashSet<UserLikePage>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string CoverImage { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeleteAt { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual ICollection<CommentPagePost> CommentPagePosts { get; set; }
        public virtual ICollection<CommentStatus> CommentStatuses { get; set; }
        public virtual ICollection<Follow> FollowFollowers { get; set; }
        public virtual ICollection<Follow> FollowUsers { get; set; }
        public virtual ICollection<Friend> FriendFriendNavigations { get; set; }
        public virtual ICollection<Friend> FriendUsers { get; set; }
        public virtual ICollection<MessageMxh> MessageMxhReceivers { get; set; }
        public virtual ICollection<MessageMxh> MessageMxhSenders { get; set; }
        public virtual ICollection<PageMxh> PageMxhs { get; set; }
        public virtual ICollection<ReactPagePost> ReactPagePosts { get; set; }
        public virtual ICollection<ReactStatus> ReactStatuses { get; set; }
        public virtual ICollection<StatusMxh> StatusMxhs { get; set; }
        public virtual ICollection<UserLikePage> UserLikePages { get; set; }
    }
}
