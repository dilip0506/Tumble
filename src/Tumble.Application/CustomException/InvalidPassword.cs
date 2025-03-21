using System;

namespace Tumble.Application.CustomException
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
