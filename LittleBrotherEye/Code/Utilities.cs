using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace LittleBrotherEye.Code
{
    public static class Utilities
    {
        public static bool SendAPIKey(string email)
        {
            using (var daAPIKeys = new DataAccess.DataAccessObjects.APIKey())
            {
                var key = daAPIKeys.LoadAPIKey(email);

                if (key != null)
                {
                    var msg = new SendGridMessage();

                    msg.SetFrom("no-reply@LittleBrotherEye.com");


                    msg.SetTemplateId("292fe174-26c0-429e-83f6-7443d85eb63e");

                    //string content = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Views/Shared/Other/Email.html"));

                    //content = content.Replace("{email}", email).Replace("{apiKey}", key.APIKey1.ToString());

                    //msg.AddContent(MimeType.Html, content);

                    //msg.Personalizations = new List<Personalization>() {
                    //    new Personalization()
                    //    {
                    //        Tos = new List<EmailAddress>() { new EmailAddress(email) }
                    //    }
                    //};

                    msg.AddTo(key.Email);

                    msg.AddSubstitutions(new Dictionary<string, string>() {
                        { "-email-", email },
                        { "-apiKey-", key.APIKey1.ToString() }
                    });

                    string SG_APIKey = ConfigurationManager.AppSettings["SendGridApiKey"];
                    var client = new SendGridClient(SG_APIKey);
                    var response = client.SendEmailAsync(msg).Result;
                }

                return (key != null);
            }

        }
    }
}