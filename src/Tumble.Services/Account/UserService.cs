using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tumble.Core.DataAccess.Interface.Account;
using Tumble.Core.Services.Interface.Account;
using Tumble.DTO.Entity;

namespace Tumble.Services.Account
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
