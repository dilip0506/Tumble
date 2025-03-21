using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tumble.DTO.Entity;
using Tumble.DTO.Model.Account;

namespace Tumble.Core.Services.Interface.Account
{
    public interface IAuthenticationService
    {
        public Task<TumbleUser> AuthenticateUser(AuthenticationModel loginDetails);
    }
}
