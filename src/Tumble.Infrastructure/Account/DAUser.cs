using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tumble.Core.DataAccess.Interface.Account;
using Tumble.DTO.Entity;
using Tumble.DTO.Model.Account;
using Dapper;

namespace Tumble.DataAccess.Account
{
    class DAUser : PostgreConnection, IDAUser
    {
        public DAUser(IOptions<Settings> settings) : base(settings){}

        public async Task<TumbleUser> GetUserByEmail(string Email)
        {
            using var conn = GetConnection();
            return await conn.QuerySingleOrDefaultAsync<TumbleUser>(UsersQueries.SelectUser, new { Email });
        }
    }
}
