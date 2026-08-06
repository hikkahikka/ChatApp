using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChatClient.Validation
{
    public class PasswordValidator: IValidator
    {
        private ConsoleUI _consoleUI;
        private const int MinLength = 6;
        private const int MaxLength = 25;
        public PasswordValidator(ConsoleUI consoleUI)
        {
            _consoleUI = consoleUI;
        }

        public bool Validate(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                _consoleUI.DisplayError("Password cannot be null or empty.");
                return false;
            }

            if (str.Length < MinLength)
            {
                _consoleUI.DisplayError($"Password must be at least {MinLength} characters long.");
                return false;
            }
            if (str.Length > MaxLength)
            {
                _consoleUI.DisplayError($"Password must be no more than {MaxLength} characters long.");
                return false;
            }
            return true;
        }
        
    }
}
