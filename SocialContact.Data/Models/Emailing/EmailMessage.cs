using System;
using System.Collections.Generic;
using System.Text;

namespace SocialContact.Data.Models.Emailing
{
    public class EmailMessage
    {

        public List<EmailAddress> ToAddress { get; set; }

        public List<EmailAddress> FromAddress { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public EmailMessage()
        {
            ToAddress = new List<EmailAddress>();

            FromAddress = new List<EmailAddress>();
        }

    }
}
