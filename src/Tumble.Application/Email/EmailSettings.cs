using System;
using System.Collections.Generic;
using System.Text;

namespace Tumble.Services.Email
{
    public class EmailSettings
    {
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
