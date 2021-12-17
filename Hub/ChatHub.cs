using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using Social_network.Models;


namespace Social_network.Hubs
{
    public class ChatHub : Hub
    {
        public async Task JoinRoom(ChatModel userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);

            // _connections[Context.ConnectionId] = userConnection;

            // await Clients.Group(userConnection.Room).SendAsync("ReceiveMessage", "Duy", $"{userConnection.User} has joined {userConnection.Room}");

            // await SendUsersConnected(userConnection.Room);
        }

        public async Task SendMessage(string message, string user, string room)
        {
            await Clients.Group(room).SendAsync("ReceiveMessage", user, message);
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
    }
}