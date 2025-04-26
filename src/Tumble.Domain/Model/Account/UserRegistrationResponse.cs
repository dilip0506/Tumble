using Tumble.User.Domain.Enum.Account;

namespace Tumble.User.Domain.Model.Account
{
    public class UserRegistrationResponse
    {
        public int UserId { get; set; }
        public UserRegistrationStatusCode RegistrationStutus { get; set; }
        public string Token { get; set; }
    }
}
