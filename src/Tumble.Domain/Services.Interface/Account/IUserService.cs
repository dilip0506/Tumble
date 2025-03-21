using System.Threading.Tasks;
using Tumble.Domain.Entity;

namespace Tumble.Domain.Services.Interface.Account
{
    public interface IUserService
    {
        Task<TumbleUser> GetUserByEmail(string Email);
    }
}
