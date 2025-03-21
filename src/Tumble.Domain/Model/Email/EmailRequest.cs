using System;
using System.Collections.Generic;
using System.Text;

namespace Tumble.DTO.Model.Email
{
    public class EmailRequest
    {
        public string ToEmail { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
