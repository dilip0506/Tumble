using System;
using System.Collections.Generic;
using System.Text;
using Tumble.DTO.Enum.Account;

namespace Tumble.DTO.Entity
{
    public class UserRegistrationVerification
    {
        public int UserId { get; set; }
        public int VerficationCode { get; set; }
        public UserRegistrationStatusCode StatusCode { get; set; }
    }
}
