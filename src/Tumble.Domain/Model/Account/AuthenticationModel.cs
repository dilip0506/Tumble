using System.ComponentModel.DataAnnotations;

namespace Tumble.Domain.Model.Account
{
    public class AuthenticationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
