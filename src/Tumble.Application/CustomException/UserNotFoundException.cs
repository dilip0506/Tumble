using System;

namespace Tumble.Application.CustomException
{
    public class UserNotFoundException : ArgumentException
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}
