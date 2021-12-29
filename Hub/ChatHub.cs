using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using Social_network.Models;
using Social_network.Data;
using Social_network.Helper;
using Microsoft.EntityFrameworkCore;

namespace Social_network.Hubs
{
    public class ChatHub : Hub
    {
        private readonly MXHContext _context;
        public ChatHub(MXHContext context) 
        {
            _context = context;
        }
        public async Task JoinRoom(ChatModel userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);

            // _connections[Context.ConnectionId] = userConnection;

            // await Clients.Group(userConnection.Room).SendAsync("ReceiveMessage", "Duy", $"{userConnection.User} has joined {userConnection.Room}");

            // await SendUsersConnected(userConnection.Room);
        }
        public async Task JoinRoomChat(ChatModel userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room + userConnection.User);
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.User + userConnection.Room);
        }

        public async Task SendMessage(string message, string fromId, string toId)
        {
            MessageMxh mes = new MessageMxh();
            mes.content = message;
            mes.createAt = DateTime.Now;
            mes.senderId = fromId;
            mes.receiverId = toId;
            mes.isRead = false;

            _context.MessageMxhs.Add(mes);
            await _context.SaveChangesAsync();

            await Clients.Group(fromId + toId).SendAsync("ReceiveMessage", mes);

            var user = (from u in _context.UserMxhs
                        where u.id == mes.senderId
                        select u).FirstOrDefault();
            var mesNoti = new {
                mes.content,
                mes.createAt,
                mes.id,
                mes.isRead,
                mes.receiverId,
                mes.senderId,
                user.avatar,
                user.firstName,
                user.lastName,
            };
            
            await Clients.Group(toId).SendAsync("MessageNotification", mesNoti);
        }

        // public override Task OnDisconnectedAsync(Exception exception)
        // {
        //     if (_connections.TryGetValue(Context.ConnectionId, out ChatModel userConnection))
        //     {
        //         _connections.Remove(Context.ConnectionId);
        //         // Clients.Group(userConnection.Room).SendAsync("ReceiveMessage", _botUser, $"{userConnection.User} has left");
        //         // SendUsersConnected(userConnection.Room);
        //     }

        //     return base.OnDisconnectedAsync(exception);
        // }

        // public Task SendUsersConnected(string room)
        // {
        //     var users = _connections.Values
        //         .Where(c => c.Room == room)
        //         .Select(c => c.User);

        //     return Clients.Group(room).SendAsync("UsersInRoom", users);
        // }
        
        // Comment
        public async Task SendComment(string comment, string statusId, string userId)
        {
            var cmt = new CommentStatus ();
            cmt.content = comment;
            cmt.createAt = DateTime.Now;
            cmt.updateAt = DateTime.Now;
            cmt.statusId = statusId;
            cmt.userId = userId;
            _context.CommentStatuses.Add(cmt);
            await _context.SaveChangesAsync();


            var query = await (from c in _context.CommentStatuses
                        where c.statusId == statusId
                        select c).ToListAsync();
            List<object> result = new List<object>();
            foreach (var item in query)
            {
                var user = (from u in _context.UserMxhs
                            where u.id == item.userId
                            select u).FirstOrDefault();
                result.Add(new {
                item.content,
                item.createAt,
                item.id,
                item.statusId,
                item.updateAt,
                item.userId,
                user.avatar,
                username = user.lastName + " " + user.firstName,
                });
            }

            await Clients.Group(statusId.ToString()).SendAsync("ReceiveComment", result);

            var status = (from s in _context.StatusMxhs
                            where s.statusId == statusId
                            select s).FirstOrDefault();
            if (status.ownerId != userId) 
            {
                var noti = new Notification();
                var sta = (from s in _context.StatusMxhs
                            where s.statusId == statusId
                            select s.ownerId).FirstOrDefault();
                var user = (from u in _context.UserMxhs
                            where u.id == userId
                            select u).FirstOrDefault();
                noti.content = $"{user.lastName} {user.firstName} đã bình luận về bài viết của bạn.";
                noti.createAt = DateTime.Now;
                noti.fromId = userId;
                noti.postId = statusId;
                noti.toId = sta;
                noti.updateAt = DateTime.Now;
                noti.type = 1; // comment
                noti.isRead = false;
                _context.Notifications.Add(noti);
                await _context.SaveChangesAsync();

                var noti2 = new {
                    content = noti.content,
                    statusId = noti.postId,
                    fromId = noti.fromId,
                    createAt = noti.createAt,
                    updateAt = noti.updateAt,
                    toId = noti.toId,
                    // id = noti.id,
                    isRead = noti.isRead,
                    type = noti.type,
                    user.avatar,
                    user.firstName,
                    user.lastName,
                };
                await Clients.Group(sta.ToString()).SendAsync("Notification", noti2);
            }
        }
        public async Task DeleteComment(int commentId, string statusId, string userId)
        {
            var comment = (from c in _context.CommentStatuses
                            where c.id == commentId 
                            where c.statusId == statusId
                            where c.userId == userId
                            select c).FirstOrDefault();
            _context.CommentStatuses.Remove(comment);
            await _context.SaveChangesAsync();


            var query = await (from c in _context.CommentStatuses
                        where c.statusId == statusId
                        select c).ToListAsync();
            List<object> result = new List<object>();
            foreach (var item in query)
            {
                var user = (from u in _context.UserMxhs
                            where u.id == item.userId
                            select u).FirstOrDefault();
                result.Add(new {
                item.content,
                item.createAt,
                item.id,
                item.statusId,
                item.updateAt,
                item.userId,
                user.avatar,
                username = user.lastName + " " + user.firstName,
                });
            }
            await Clients.Group(statusId.ToString()).SendAsync("ReceiveComment", result);
        }
        public async Task UpdateComment(int commentId, string content, string statusId, string userId)
        {
            var comment = (from c in _context.CommentStatuses
                            where c.id == commentId 
                            where c.statusId == statusId
                            where c.userId == userId
                            select c).FirstOrDefault();
            comment.content = content;
            comment.updateAt = DateTime.Now;
            await _context.SaveChangesAsync();

            var query = await (from c in _context.CommentStatuses
                        where c.statusId == statusId
                        select c).ToListAsync();
            List<object> result = new List<object>();
            foreach (var item in query)
            {
                var user = (from u in _context.UserMxhs
                            where u.id == item.userId
                            select u).FirstOrDefault();
                result.Add(new {
                item.content,
                item.createAt,
                item.id,
                item.statusId,
                item.updateAt,
                item.userId,
                user.avatar,
                username = user.lastName + " " + user.firstName,
                });
            }
            await Clients.Group(statusId.ToString()).SendAsync("ReceiveComment", result);
        }

        public async Task AddFriend (string me, string friendId) 
        {
            var noti = new Notification();
            var user = (from u in _context.UserMxhs
                        where u.id == me
                        select u).FirstOrDefault();
            noti.content = $"{user.lastName} {user.firstName} đã gửi lời mời kết bạn.";
            noti.createAt = DateTime.Now;
            noti.fromId = me;
            noti.postId = null;
            noti.toId = friendId;
            noti.updateAt = DateTime.Now;
            noti.type = 2; // add friend
            noti.isRead = false;
            noti.UserFrom = user;
            _context.Notifications.Add(noti);
            await _context.SaveChangesAsync();
            var noti2 = new {
                content = noti.content,
                statusId = noti.postId,
                fromId = noti.fromId,
                createAt = noti.createAt,
                updateAt = noti.updateAt,
                toId = noti.toId,
                // id = noti.id,
                isRead = noti.isRead,
                type = noti.type,
                user.avatar,
                user.firstName,
                user.lastName,
            };
            await Clients.Group(friendId).SendAsync("Notification", noti2);
        } 

        public async Task callUser (VideoModel data) 
        {
            await Clients.Group(data.toId).SendAsync("callUser", data);
        }

        public async Task answerCall (AnswerCallModel data) 
        {
            await Clients.Group(data.toId).SendAsync("callAccepted", data.signal);
        }

        public async Task endCall (string toId) 
        {
            await Clients.Group(toId).SendAsync("callEnded");
        }

        // private async Task<List<object>> GetCmt (string statusId)
        // {
        //     var query = await (from c in _context.CommentStatuses
        //                 where c.statusId == statusId
        //                 select c).ToListAsync();
        //     List<object> result = new List<object>();
        //     foreach (var item in query)
        //     {
        //         var user = (from u in _context.UserMxhs
        //                     where u.id == item.userId
        //                     select u).FirstOrDefault();
        //         result.Add(new {
        //         item.content,
        //         item.createAt,
        //         item.id,
        //         item.statusId,
        //         item.updateAt,
        //         item.userId,
        //         user.avatar,
        //         username = user.lastName + " " + user.firstName,
        //         });
        //     }

        //     return result;
        // }
    }
}