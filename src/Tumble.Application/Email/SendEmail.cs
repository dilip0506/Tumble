using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;
using Tumble.User.Domain.Model.Email;
using Tumble.User.Domain.Services.Interface.Email;

namespace Tumble.User.Application.Email
{
    class SendEmail : ISendEmail
    {
        private readonly EmailSettings _emailSettings;
        public SendEmail(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task SendEmailAsync(EmailRequest emailRequest)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailSettings.FromName, _emailSettings.FromEmail));
            emailMessage.To.Add(new MailboxAddress(emailRequest.ToName, emailRequest.ToEmail));
            emailMessage.Subject = emailRequest.Subject;
            emailMessage.Body = new TextPart("plain")
            {
                Text = emailRequest.Body
            };

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                smtpClient.Authenticate(_emailSettings.SmtpUserName, _emailSettings.SmtpPassword);
                await smtpClient.SendAsync(emailMessage);
                smtpClient.Disconnect(true);
            }
            ;
        }
    }
}
