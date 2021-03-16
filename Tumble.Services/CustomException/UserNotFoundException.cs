using System;
using System.Collections.Generic;
using System.Text;

namespace Tumble.Services.CustomException
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
