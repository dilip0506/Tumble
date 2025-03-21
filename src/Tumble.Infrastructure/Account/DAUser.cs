using Dapper;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Tumble.Domain.DataAccess.Interface.Account;
using Tumble.Domain.Entity;

namespace Tumble.Infrastructure.Account
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
