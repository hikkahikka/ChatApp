using System;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.SignalR.Client;
public record UserConnection(string UserName, string ChatRoom);
class Program
{
    static async Task Main(string[] args)
    {

        string userName = EnterName();
        while (true)
        {
            string chatRoom = EnterChatRoom();
            if (chatRoom == "/quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            var userConnection = new UserConnection(userName, chatRoom);
            HubConnection connection = await StartConnection(userConnection);
            if (connection == null) continue;

            await RunChatLoop(connection, userConnection);
        }
    }
   
    private static async Task LeaveChat(HubConnection connection, UserConnection userConnection)
    {
        try {
            await connection.InvokeAsync("LeaveChat", userConnection);
        }
        finally
        {
            await connection.DisposeAsync();
        }

        Console.WriteLine($"You leave {userConnection.ChatRoom}");
    }
    private static string EnterName()
    {
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine() ?? "Anonimus";
        return userName;
    }
    private static string EnterChatRoom()
    {
        Console.Write("Enter chat room name: ");
        string chatRoom = Console.ReadLine() ?? "General";
        return chatRoom;
    }
    private async static Task RunChatLoop(HubConnection connection, UserConnection userConnection)
    {
        while (true)
        {
            Console.Write("> ");
            string message = Console.ReadLine() ?? "";
            if (message == "/exit")
            {
                await LeaveChat(connection, userConnection);
                break;
            }
            if (!string.IsNullOrEmpty(message))
            {
                await connection.InvokeAsync("SendMessage", userConnection, message);
            }
        }
    }
    private async static Task<HubConnection> StartConnection(UserConnection userConnection)
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5000/chat")
            .WithAutomaticReconnect()
            .Build();

        RegisterHandlers(connection);

        try
        {
            Console.WriteLine("Connetion...");
            await connection.StartAsync();

            await connection.InvokeAsync("JoinChat", userConnection);
            return connection;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }
    private static void RegisterHandlers(HubConnection connection)
    {
        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            Console.WriteLine($"\n[{user}]: {message}");
            Console.Write("> ");
        });
    }
}
