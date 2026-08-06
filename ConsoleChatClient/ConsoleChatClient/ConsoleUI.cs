using ConsoleChatClient.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleChatClient
{
    public class ConsoleUI
    {
        public void DisplayError(string message)
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error]: {message}");
            Console.ForegroundColor = defaultColor;
        }
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
            IValidator validator = new LoginValidator(this);
            while (true)
            {
                Console.Write("Enter your name (login): ");
                string? userName = Console.ReadLine();
                if (validator.Validate(userName))
                {
                    return userName;
                }
            }
        }
        public string AskChatRoomName()
        {
            IValidator validator = new ChatRoomValidator(this);
            while (true)
            {
                Console.Write("Enter chat room name (or \"/exit\" to exit): ");
                string? chatRoom = Console.ReadLine();
                if (validator.Validate(chatRoom))
                {
                    return chatRoom;
                }
            }
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
