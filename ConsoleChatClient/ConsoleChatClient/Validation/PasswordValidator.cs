using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChatClient.Validation
{
    public class PasswordValidator
    {
        private ConsoleUI _consoleUI;
        private const int MinLength = 6;
        private const int MaxLength = 25;
        public PasswordValidator(ConsoleUI consoleUI)
        {
            _consoleUI = consoleUI;
        }

        public bool Validate(string? str, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrEmpty(str))
            {
                errorMessage = "Password cannot be null or empty.";
                return false;
            }

            if (str.Length < MinLength)
            {
                errorMessage = $"Password must be at least {MinLength} characters long.";
                return false;
            }
            if (str.Length > MaxLength)
            {
                errorMessage = $"Password must be no more than {MaxLength} characters long.";
                return false;
            }
            return true;
        }
        
    }
}
