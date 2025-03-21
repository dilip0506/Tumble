using System.Threading.Tasks;
using Tumble.Domain.DataAccess.Interface.Account;
using Tumble.Domain.Entity;
using Tumble.Domain.Services.Interface.Account;

namespace Tumble.Application.Account
{
    class UserService : IUserService
    {
        private readonly IDAUser _daUser;

        public UserService(IDAUser daUser)
        {
            _daUser = daUser;
        }
        public async Task<TumbleUser> GetUserByEmail(string Email)
        {
            return await _daUser.GetUserByEmail(Email);
        }
    }
}
