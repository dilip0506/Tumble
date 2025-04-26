using System.Threading.Tasks;
using Tumble.User.Domain.Model.Email;

namespace Tumble.User.Domain.Services.Interface.Email
{
    public interface ISendEmail : IEmail
    {
        public Task SendEmailAsync(EmailRequest emailRequest);
    }
}
