using System.Threading.Tasks;
using Tumble.User.Domain.Model.Account;

namespace Tumble.User.Domain.Services.Interface.Account
{
    public interface IRegistrationService
    {
        public Task<UserRegistrationResponse> CreateUser(RegistrationModel tumbleUser);
    }
}
