using System.Threading.Tasks;
using Tumble.User.Domain.Entity;

namespace Tumble.User.Domain.DataAccess.Interface.Account
{
    public interface IDARegistrartion
    {
        public Task<int> InsertUser(TumbleUser tumbleUser);

        public Task<int> InsertAddress(Address userAddress);

        public Task<int> InsertRegistrationPin(UserRegistrationVerification verificationDetails);
    }
}
