using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChatClient.Validation
{
    internal interface IValidator
    {
        bool Validate(string str);

    }
}
