using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SocialContact.Common
{
    public class NotificationHelper
    {
        public static string EmailSenderNotification(string fullName, string routePath, Dictionary<string, string> queryParams, string templateFilename, HttpContext context)
        {
            var baseUrl = UrlHelper.BaseAddress(context);

            var link = UrlHelper.GetEmailLink(queryParams, routePath, context);

            var templatePath = string.Join("\\", "..\\SocialContact" + "\\ClientApp\\public\\Templates", templateFilename);

            var htmlContent = File.ReadAllText(templatePath);

            htmlContent = htmlContent.Replace("[name]", fullName);
            htmlContent = htmlContent.Replace("[baseAddress]", baseUrl);
            htmlContent = htmlContent.Replace("[link]", link);

            return htmlContent;
            
        }
    }
}
