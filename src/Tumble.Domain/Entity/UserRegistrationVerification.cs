using Tumble.User.Domain.Enum.Account;

namespace Tumble.User.Domain.Entity
{
    public class UserRegistrationVerification
    {
        public int UserId { get; set; }
        public int VerficationCode { get; set; }
        public UserRegistrationStatusCode StatusCode { get; set; }
    }
}
