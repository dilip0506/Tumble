namespace Tumble.Domain.Entity
{
    public class TumbleUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
