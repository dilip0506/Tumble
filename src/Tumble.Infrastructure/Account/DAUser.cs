using Dapper;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Tumble.User.Domain.DataAccess.Interface.Account;
using Tumble.User.Domain.Entity;
using Tumble.User.Infrastructure;

namespace Tumble.User.Infrastructure.Account
{
    class DAUser : PostgreConnection, IDAUser
    {
        public DAUser(IOptions<Settings> settings) : base(settings) { }

        public async Task<TumbleUser> GetUserByEmail(string Email)
        {
            using var conn = GetConnection();
            return await conn.QuerySingleOrDefaultAsync<TumbleUser>(UsersQueries.SelectUser, new { Email });
        }
    }
}
