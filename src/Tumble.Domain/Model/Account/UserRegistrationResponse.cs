using System;
using System.Collections.Generic;
using System.Text;
using Tumble.DTO.Enum.Account;

namespace Tumble.DTO.Model.Account
{
    public class UserRegistrationResponse
    {
        public int UserId { get; set; }
        public UserRegistrationStatusCode RegistrationStutus { get; set; }
        public string Token { get; set; }
    }
}
