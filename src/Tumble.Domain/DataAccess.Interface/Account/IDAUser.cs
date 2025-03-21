using System.Threading.Tasks;
using Tumble.Domain.Entity;

namespace Tumble.Domain.DataAccess.Interface.Account
{
    public interface IDAUser
    {
        public Task<TumbleUser> GetUserByEmail(string email);
    }
}
