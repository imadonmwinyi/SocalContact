using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using SocialContact.Core.Services.Abstraction;
using SocialContact.Data.Models.Emailing;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SocialContact.Core.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }
        public List<EmailMessage> ReceiveEmail(int maxCount = 10)
        {
            throw new NotImplementedException();
        }

        public void SendEmail(string recipient, string content, string subject)
        {

            var message = new MimeMessage();

            //message.To.AddRange(emailMessage.ToAddress.Select(x => new MailboxAddress(x.Name, x.Address)));
            //message.From.AddRange(emailMessage.FromAddress.Select(x => new MailboxAddress(x.Name, x.Address)));

            message.To.Add(MailboxAddress.Parse(recipient));
            message.From.Add(MailboxAddress.Parse(_emailConfiguration.SmtpUsername));

            message.Subject = subject;

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = content
            };


            using (var emailClient = new SmtpClient())
            {
                //The last parameter here is to use SSL (Which you should!)
                emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);

                //Remove any OAuth functionality as we won't be using it. 
                //emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

                emailClient.Send(message);

                emailClient.Disconnect(true);
            }




        }
    }
}
