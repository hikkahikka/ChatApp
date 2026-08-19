using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChatClient.Validation
{
    public class ChatRoomValidator
    {

        private ConsoleUI _consoleUI;
        private const int MinLength = 2;
        private const int MaxLength = 25;
        public ChatRoomValidator(ConsoleUI consoleUI)
        {
            _consoleUI = consoleUI;
        }

        public bool Validate(string? str, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (str == "/exit") return true;
            if (string.IsNullOrEmpty(str))
            {
                errorMessage = "Chat room name cannot be null or empty.";
                return false;
            }

            if (str.Length < MinLength)
            {
                errorMessage = $"Chat room name must be at least {MinLength} characters long.";
                return false;
            }
            if (str.Length > MaxLength)
            {
                errorMessage = $"Chat room name must be no more than {MaxLength} characters long.";
                return false;
            }
            
            if (str.Contains("\\") || str.Contains("/"))
            {
                errorMessage = "Chat room name cannot contain slashes.";
                return false;
            }
            return true;
        }
    }
}
