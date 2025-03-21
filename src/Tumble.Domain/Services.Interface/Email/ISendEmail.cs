using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tumble.DTO.Model.Email;

namespace Tumble.Core.Services.Interface.Email
{
    public interface ISendEmail : IEmail {
        public Task SendEmailAsync(EmailRequest emailRequest);
    }
}
