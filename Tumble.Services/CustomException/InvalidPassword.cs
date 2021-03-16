using System;
using System.Collections.Generic;
using System.Text;

namespace Tumble.Services.CustomException
{
    class InvalidPassword : ArgumentException
    {
        public InvalidPassword()
        {
        }

        public InvalidPassword(string message) : base(message)
        {
        }
    }
}
