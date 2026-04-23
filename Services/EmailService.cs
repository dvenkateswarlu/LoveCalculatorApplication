using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace LoveCalculatorApp.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMail(string userName, string userEmail, string result)
        {
            var mailSettings = _configuration.GetSection("MailSettings");

            string fromEmail = mailSettings["Email"] ?? throw new Exception("Email missing");
            string password = mailSettings["Password"] ?? throw new Exception("Password missing");
            string host = mailSettings["Host"] ?? throw new Exception("Host missing");
            int port = mailSettings.GetValue<int>("Port");

            using var smtpClient = new SmtpClient(host)
            {
                Port = port,
                Credentials = new NetworkCredential(fromEmail, password),
                EnableSsl = true
            };

            using var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = "Love Calculator",
                Body = $"Hi {userName}!\nThe result predicted by the LcApp is {result}",
                IsBodyHtml = false
            };

            mailMessage.To.Add(userEmail);

            smtpClient.Send(mailMessage);
        }
    }
}