using System.Threading.Tasks;
using Tumble.User.Domain.Entity;

namespace Tumble.User.Domain.DataAccess.Interface.Account
{
    public interface IDAUser
    {
        public Task<TumbleUser> GetUserByEmail(string email);
    }
}
