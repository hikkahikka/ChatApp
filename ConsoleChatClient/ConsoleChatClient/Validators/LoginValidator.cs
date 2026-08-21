using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChatClient.Validators
{
    public class LoginValidator
    {
        private const int MinLength = 2;
        private const int MaxLength = 15;
        public bool Validate(string? str, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrEmpty(str))
            {
                errorMessage = "Login cannot be null or empty.";
                return false;
            }
            if(str.Contains(" "))
            {
                errorMessage = "Login cannot contain spaces.";
                return false;
            }
            if(str.Contains("\\") || str.Contains("/"))
            {
                errorMessage = "Login cannot contain slashes.";
                return false;
            }
            if (str.Length < MinLength)
            {
                errorMessage = $"Login must be at least {MinLength} characters long.";
                return false;
            }
            if (str.Length > MaxLength  )
            {
                errorMessage = $"Login must be no more than {MaxLength} characters long.";
                return false;
            }
            return true;
        }
    }
}
