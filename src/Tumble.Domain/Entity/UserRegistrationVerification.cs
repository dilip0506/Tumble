using Tumble.Domain.Enum.Account;

namespace Tumble.Domain.Entity
{
    public class UserRegistrationVerification
    {
        public int UserId { get; set; }
        public int VerficationCode { get; set; }
        public UserRegistrationStatusCode StatusCode { get; set; }
    }
}
