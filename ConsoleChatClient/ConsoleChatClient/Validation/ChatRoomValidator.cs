using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChatClient.Validation
{
    public class ChatRoomValidator : IValidator
    {

        private ConsoleUI _consoleUI;
        private const int MinLength = 2;
        private const int MaxLength = 25;
        public ChatRoomValidator(ConsoleUI consoleUI)
        {
            _consoleUI = consoleUI;
        }

        public bool Validate(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                _consoleUI.DisplayError("Chat room name cannot be null or empty.");
                return false;
            }

            if (str.Length < MinLength)
            {
                _consoleUI.DisplayError($"Chat room name must be at least {MinLength} characters long.");
                return false;
            }
            if (str.Length > MaxLength)
            {
                _consoleUI.DisplayError($"Chat room name must be no more than {MaxLength} characters long.");
                return false;
            }
            if (str.Contains("\\") || str.Contains("/"))
            {
                _consoleUI.DisplayError("Chat room name cannot contain slashes.");
                return false;
            }
            return true;
        }
    }
}
