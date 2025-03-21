using Tumble.Domain.Enum.Account;

namespace Tumble.Domain.Model.Account
{
    public class UserRegistrationResponse
    {
        public int UserId { get; set; }
        public UserRegistrationStatusCode RegistrationStutus { get; set; }
        public string Token { get; set; }
    }
}
