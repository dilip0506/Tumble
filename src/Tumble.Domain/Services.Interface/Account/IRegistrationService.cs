using System.Threading.Tasks;
using Tumble.Domain.Model.Account;

namespace Tumble.Domain.Services.Interface.Account
{
    public interface IRegistrationService
    {
        public Task<UserRegistrationResponse> CreateUser(RegistrationModel tumbleUser);
    }
}
