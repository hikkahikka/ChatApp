using ChatServer.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatServer.Hubs;

public interface IChatClient
{
    public Task ReceiveMessage(string userName, string message);
}
public class ChatHub : Hub<IChatClient>
{
    public async Task JoinChat(UserConnection connection)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, connection.ChatRoom);
        await Clients
            .Group(connection.ChatRoom)
            .ReceiveMessage("Admin", $"{connection.UserName} join to chat");
    }
    public async Task SendMessage(UserConnection connection, string message)
    {
        await Clients
            .Group(connection.ChatRoom)
            .ReceiveMessage(connection.UserName, message);
    }
    public async Task LeaveChat(UserConnection connection)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, connection.ChatRoom);
        await Clients
            .Group(connection.ChatRoom)
            .ReceiveMessage("Admin", $"{connection.UserName} leave chat");
    }
}