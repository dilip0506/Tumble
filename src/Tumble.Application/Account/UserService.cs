using System.Threading.Tasks;
using Tumble.User.Domain.DataAccess.Interface.Account;
using Tumble.User.Domain.Entity;
using Tumble.User.Domain.Services.Interface.Account;

namespace Tumble.User.Application.Account
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
