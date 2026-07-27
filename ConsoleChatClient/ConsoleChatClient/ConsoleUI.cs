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
            Console.ForegroundColor= GetConsoleColor(sender, currentUserName);
            Console.Write("> ");
            if (sender == currentUserName)
            {
                Console.WriteLine($"[You]: {message}");
            }
            else
            {
                Console.WriteLine($"[{sender}]: {message}");
            }
            Console.ForegroundColor = defaultColor;
        }
        public void ClearLastInputLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
        }
        public void DisplayInfo(string message)
        {
            Console.WriteLine(message);
        }
        public string AskUserName()
        {
            Console.Write("Enter your name: ");
            string? userName = Console.ReadLine();
            return string.IsNullOrWhiteSpace(userName) ? "Anonimus" : userName;
        }
        public string AskChatRoomName()
        {
            Console.Write("Enter chat room name (or \"/exit\" to exit): ");
            string? chatRoom = Console.ReadLine();
            return string.IsNullOrWhiteSpace(chatRoom) ? "General" : chatRoom;
        }
        private ConsoleColor GetConsoleColor(string sender, string currentUserName)
        {
            if (sender == currentUserName)
            {
                return ConsoleColor.Magenta;
            }
            else if (sender == "System")
            {
                return ConsoleColor.Yellow;
            }
            else
            {
                return ConsoleColor.Green;
            }
        }
    }
}
