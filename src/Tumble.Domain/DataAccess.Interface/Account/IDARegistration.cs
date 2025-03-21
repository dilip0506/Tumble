using System.Threading.Tasks;
using Tumble.Domain.Entity;

namespace Tumble.Domain.DataAccess.Interface.Account
{
    public interface IDARegistrartion
    {
        public Task<int> InsertUser(TumbleUser tumbleUser);

        public Task<int> InsertAddress(Address userAddress);

        public Task<int> InsertRegistrationPin(UserRegistrationVerification verificationDetails);
    }
}
