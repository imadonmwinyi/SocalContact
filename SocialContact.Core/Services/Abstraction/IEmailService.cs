using SocialContact.Data.Models.Emailing;
using System.Collections.Generic;

namespace SocialContact.Core.Services.Abstraction
{
    public interface IEmailService
    {
        void SendEmail(string recipient, string content, string subject);
        List<EmailMessage> ReceiveEmail(int maxCount = 10);
    }
}
