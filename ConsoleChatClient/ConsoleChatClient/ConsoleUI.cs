using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChatClient
{
    public class ConsoleUI
    {
        public void DisplayMessage(string sender, string message, string currentUserName)
        {
            var defaultColor = Console.ForegroundColor;

            if(sender == currentUserName)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"[You]: {message}");
            }
            else if(sender == "System")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[System]: {message}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[{sender}]: {message}");
            }
            Console.Write("> ");
            Console.ForegroundColor = defaultColor;
        }
        public void DisplayInfo(string message)
        {
            var defaultColor = Console.ForegroundColor;
            Console.WriteLine(message);
        }
        public string AskUserName()
        {
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine() ?? "Anonimus";
            return userName;
        }
        public string AskChatRoomName()
        {
            Console.Write("Enter chat room name (or \"/exit\" to exit): ");
            string chatRoom = Console.ReadLine() ?? "General";
            return chatRoom;
        }
    }
}
