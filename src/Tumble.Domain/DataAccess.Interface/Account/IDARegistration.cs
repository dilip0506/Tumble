using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tumble.DTO.Entity;

namespace Tumble.Core.DataAccess.Interface.Account
{
    public interface IDARegistrartion
    {
        public Task<int> InsertUser(TumbleUser tumbleUser);

        public Task<int> InsertAddress(Address userAddress);

        public Task<int> InsertRegistrationPin(UserRegistrationVerification verificationDetails);
    }
}
