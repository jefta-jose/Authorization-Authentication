using System.Net.Mail;
using System.Net;

namespace api.Services.EmailService
{
    public static class EmailSenderService
    {
        private const string SmtpServer = "smtp.gmail.com";
        private const int SmtpPort = 587;
        private const string SenderEmail = "ndegwajeff4@gmail.com";
        public static async Task SendEmailAsync(string toEmail, string subject, string body, string AppPassword)
        {
            try
            {
                using var smtpClient = new SmtpClient(SmtpServer)
                {
                    Port = SmtpPort,
                    Credentials = new NetworkCredential(SenderEmail, AppPassword),
                    EnableSsl = true            
                };

                using var mailMessage = new MailMessage
                {
                    From = new MailAddress(SenderEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);
                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message} : {ex.InnerException?.Message}");
            }
        }

    }
}
