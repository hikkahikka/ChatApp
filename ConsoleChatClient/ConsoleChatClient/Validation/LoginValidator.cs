using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChatClient.Validation
{
    public class LoginValidator : IValidator
    {
        private ConsoleUI _consoleUI;
        private const int MinLength = 2;
        private const int MaxLength = 15;
        public LoginValidator(ConsoleUI consoleUI)
        {
            _consoleUI = consoleUI;
        }
        public bool Validate(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                _consoleUI.DisplayError("Login cannot be null or empty.");
                return false;
            }
            if(str.Contains(" "))
            {
                _consoleUI.DisplayError("Login cannot contain spaces.");
                return false;
            }
            if(str.Contains("\\") || str.Contains("/"))
            {
                _consoleUI.DisplayError("Login cannot contain slashes.");
                return false;
            }
            if (str.Length < MinLength)
            {
                _consoleUI.DisplayError($"Login must be at least {MinLength} characters long.");
                return false;
            }
            if (str.Length > MaxLength  )
            {
                _consoleUI.DisplayError($"Login must be no more than {MaxLength} characters long.");
                return false;
            }
            return true;
        }
    }
}
