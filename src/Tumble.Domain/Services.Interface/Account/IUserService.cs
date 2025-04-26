using System.Threading.Tasks;
using Tumble.User.Domain.Entity;

namespace Tumble.User.Domain.Services.Interface.Account
{
    public interface IUserService
    {
        Task<TumbleUser> GetUserByEmail(string Email);
    }
}
