using System.Threading.Tasks;
using Tumble.Domain.Entity;
using Tumble.Domain.Model.Account;

namespace Tumble.Domain.Services.Interface.Account
{
    public interface IAuthenticationService
    {
        public Task<TumbleUser> AuthenticateUser(AuthenticationModel loginDetails);
    }
}
