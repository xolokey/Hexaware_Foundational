using AssertManagementAPI.Model;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace AssertManagementAPI.Authentication.AuthServices
{


    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            //var mail = new MailMessage
            //{
            //    From = new MailAddress(_settings.SenderEmail, _settings.SenderName),
            //    Subject = subject,
            //    Body = body,
            //    IsBodyHtml = true
            //};

            //mail.To.Add(toEmail);

            //using var smtp = new SmtpClient(_settings.SmtpServer, _settings.Port)
            //{
            //    Credentials = new NetworkCredential(_settings.SenderEmail, _settings.Password),
            //    EnableSsl = true
            //};

            //await smtp.SendMailAsync(mail);
            var smtp = new SmtpClient(_settings.SmtpServer, _settings.Port)
            {
                Credentials = new NetworkCredential("apikey", _settings.Password),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_settings.SenderEmail, _settings.SenderName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mail.To.Add(toEmail);
            await smtp.SendMailAsync(mail);

        }
    }

}
