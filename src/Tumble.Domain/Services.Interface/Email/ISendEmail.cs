using System.Threading.Tasks;
using Tumble.Domain.Model.Email;

namespace Tumble.Domain.Services.Interface.Email
{
    public interface ISendEmail : IEmail
    {
        public Task SendEmailAsync(EmailRequest emailRequest);
    }
}
