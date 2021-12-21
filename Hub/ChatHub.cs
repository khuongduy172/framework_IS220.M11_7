using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using Social_network.Models;
using Social_network.Data;
using Social_network.Helper;

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

            await Clients.Group(fromId + toId).SendAsync("ReceiveMessage", mes);
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
            // _context.CommentStatuses.Add(cmt);
            // await _context.SaveChangesAsync();

            var noti = new Notification();
            var sta = (from s in _context.StatusMxhs
                        where s.statusId == statusId
                        select s.ownerId).First();
            // var user = await _helper.GetUserById(userId);
            noti.content = $"{userId} đã bình luận về bài viết của bạn.";
            noti.createAt = DateTime.Now;
            noti.fromId = userId;
            noti.postId = statusId;
            noti.toId = sta;
            noti.updateAt = DateTime.Now;
            noti.type = 1; // comment
            // _context.Notifications.Add(noti);
            // await _context.SaveChangesAsync();

            await Clients.Group(statusId.ToString()).SendAsync("ReceiveComment", cmt);
            await Clients.Group(sta.ToString()).SendAsync("Notification", noti);
        }
    }
}