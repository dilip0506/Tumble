using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tumble.Core.DataAccess.Interface.Account;
using Tumble.DTO.Entity;

namespace Tumble.DataAccess.Account
{
    class DARegistrartion : PostgreConnection, IDARegistrartion
    {

        public DARegistrartion(IOptions<Settings> settings) :base(settings){}

        public async Task<int> InsertUser(TumbleUser tumbleUser)
        {
            using var conn = GetConnection();
            return await conn.QuerySingleOrDefaultAsync<int>(UsersQueries.InsertUser, tumbleUser);
        }

        public async Task<int> InsertAddress(Address userAddress)
        {
            using var conn = GetConnection();          
            return await conn.QuerySingleOrDefaultAsync<int>(UsersQueries.InsertAddress, userAddress);
        }

        public async Task<int> InsertRegistrationPin(UserRegistrationVerification verificationDetails)
        {
            using var conn = GetConnection();
            return await conn.ExecuteAsync(UsersQueries.InsertRegistrationVerificationDetails, verificationDetails);
        }
    }
}
