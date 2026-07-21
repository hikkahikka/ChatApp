using System;
using System.Net.NetworkInformation;
using ConsoleChatClient;
using Microsoft.AspNetCore.SignalR.Client;

class Program
{
    private const string URL = "http://localhost:5000/chat";
    public static async Task Main(string[] args)
    {
        var consoleUI = new ConsoleUI();
        string userName = consoleUI.AskUserName();
        while (true)
        {
            string chatRoom = consoleUI.AskChatRoomName();
            if (chatRoom == "/exit") break;

            UserConnection userConnection = new UserConnection(userName, chatRoom);

            ChatService chatService = new ChatService(URL);

            chatService.OnMessageReceived += (sender, message) =>
            {
                consoleUI.DisplayMessage(sender, message, userName);
            };
            try
            {
                consoleUI.DisplayInfo("Connection...");
                await chatService.GetConnectionAsync(userConnection);
                consoleUI.DisplayInfo($"You are now connected to the chat room {chatRoom}. Enter \"/quit\" to disconnect.");
                await RunChatLoop(chatService, userConnection, consoleUI);
            }
            catch(Exception ex)
            {
                consoleUI.DisplayInfo($"Connection error: {ex.Message}");
            }
        }
    }
    private static async Task RunChatLoop(ChatService chatService, UserConnection userConnection, ConsoleUI consoleUI)
    {
        while (true)
        {
            string message = Console.ReadLine() ?? "";
            if (message == "/quit")
            {
                await chatService.LeaveChatAsync(userConnection);
                consoleUI.DisplayInfo("You have left the chat room.");
                break;
            }
            else
            {
                await chatService.SendMessageAsync(userConnection, message);
            }
        }
    }
}
