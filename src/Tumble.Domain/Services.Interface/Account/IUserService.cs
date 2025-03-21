using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tumble.DTO.Entity;

namespace Tumble.Core.Services.Interface.Account
{
    public interface IUserService
    {
        Task<TumbleUser> GetUserByEmail(string Email);
    }
}
