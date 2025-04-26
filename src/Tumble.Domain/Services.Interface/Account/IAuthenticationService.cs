using System.Threading.Tasks;
using Tumble.User.Domain.Entity;
using Tumble.User.Domain.Model.Account;

namespace Tumble.User.Domain.Services.Interface.Account
{
    public interface IAuthenticationService
    {
        public Task<TumbleUser> AuthenticateUser(AuthenticationModel loginDetails);
    }
}
