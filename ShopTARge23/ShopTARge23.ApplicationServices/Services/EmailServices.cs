using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Core.Dto;
using MimeKit;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;

namespace ShopTARge23.ApplicationServices.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly IConfiguration _configuration;

        public EmailServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(EmailDto dto)
        {
            // appsettingust loeb andmed
            var host = _configuration["EmailSettings:SMTPHost"];
            var username = _configuration["EmailSettings:Email"];
            var password = _configuration["EmailSettings:Password"];
            var port = int.Parse(_configuration["EmailSettings:SMTPPort"]);

            var email = new MimeMessage();
            // otsida üles config ja sis. muutujad // "EmailHost": asdsad; "EmailUsername": asdsa;"EmailPassword": asda
            email.From.Add(new MailboxAddress("Ronald R", username)); // mis nime/emaili kuvab saajale
            email.To.Add(new MailboxAddress("", dto.To));
            email.Subject = dto.Subject;

            // email body
            var bodyBuilder = new BodyBuilder
            {
                TextBody = dto.Body
            };

            email.Body = bodyBuilder.ToMessageBody();

            // emaili saatmine 

            using var smtpClient = new SmtpClient();
            try
            {
                smtpClient.Connect(host, port, MailKit.Security.SecureSocketOptions.StartTls);
                smtpClient.Authenticate(username, password);
                smtpClient.Send(email);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to send email: {ex.Message}, ex");
            }
            finally
            {
                smtpClient.Dispose();
            }

        }
    }
}
