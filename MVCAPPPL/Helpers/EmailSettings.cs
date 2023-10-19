using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MVCAPPDAL.Models;
using MVCAPPPL.Helpers;
using MVCAPPPL.Settings;
using System.Net;
using System.Net.Mail;

namespace MVCPL.Helpers
{
    public  class EmailSettings : IEmailSettings
    {
        private readonly MailSettings _options;

        //public static void SendEmail(Email email)
        //{
        //	
        //	var client = new SmtpClient("smtp.gmail.com", 587);
        //	client.EnableSsl = true;
        //	client.Credentials = new NetworkCredential("samy07002@gmail.com", "niqveavdmjcgmgsp");
        //	client.Send("samy07002@gmail.com", email.To, email.Subject, email.Body);
        //}
        public EmailSettings(IOptions<MailSettings> options)
        {
            _options = options.Value;
        }
        public void SendEmail(Email email)
        {
            var mail = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_options.SenderEmail),
                Subject = email.Subject,

            };
            mail.To.Add(MailboxAddress.Parse(email.To));
            var builder = new BodyBuilder();
            builder.TextBody = email.Body;
            mail.Body = builder.ToMessageBody();
            mail.From.Add(new MailboxAddress(_options.SenderName,_options.SenderEmail));
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_options.SmtpServer, _options.SmtpPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(_options.SenderEmail, _options.Password);
            smtp.Send(mail);
            smtp.Disconnect(true);
        }
    }
}
