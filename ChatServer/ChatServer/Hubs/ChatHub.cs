using ChatServer.Models.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace ChatServer.Hubs;
public class ChatHub : Hub<IChatClient>
{
    public async Task JoinChat(UserDTO connection)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, connection.ChatRoom);
        await Clients
            .Group(connection.ChatRoom)
            .ReceiveMessage("System", $"{connection.UserName} join to chat");
    }
    public async Task SendMessage(UserDTO connection, string message)
    {
        await Clients
            .Group(connection.ChatRoom)
            .ReceiveMessage(connection.UserName, message);
    }
    public async Task LeaveChat(UserDTO connection)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, connection.ChatRoom);
        await Clients
            .Group(connection.ChatRoom)
            .ReceiveMessage("System", $"{connection.UserName} leave chat");
    }
}