﻿using SocialContact.Core.Services.Abstraction;

namespace SocialContact.Core.Services.Implementation
{
    public class EmailConfiguration:IEmailConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
    }
}
