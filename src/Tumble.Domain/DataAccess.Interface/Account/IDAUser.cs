using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tumble.DTO.Entity;
using Tumble.DTO.Model.Account;

namespace Tumble.Core.DataAccess.Interface.Account
{
    public interface IDAUser
    {
        public Task<TumbleUser> GetUserByEmail(string email);
    }
}
