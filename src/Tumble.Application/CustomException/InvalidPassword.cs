using System;

namespace Tumble.User.Application.CustomException
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
