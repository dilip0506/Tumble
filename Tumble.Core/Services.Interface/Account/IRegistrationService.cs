using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tumble.DTO.Model.Account;

namespace Tumble.Core.Services.Interface.Account
{
    public interface IRegistrationService
    {
        public Task<UserRegistrationResponse> CreateUser(RegistrationModel tumbleUser);
    }
}
