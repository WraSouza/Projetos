
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Projects.Infrastructure.Notifications
{
    public class EmailService(ISendGridClient client, IConfiguration configuration) : IEmailService
    {
        public async Task SendAsync(string email, string subject, string message)
        {

            var fromEmail = configuration.GetValue<string>("SendGrid:FromEmail");
            var fromName = configuration.GetValue<string>("SendGrid:FromName");

            var sendGridMessage = new SendGridMessage
            {
                From = new EmailAddress(fromEmail, fromName),
                Subject = subject,
            };

            sendGridMessage.AddContent(MimeType.Text, message);

            sendGridMessage.AddTo(new EmailAddress(email));

            var response = await client.SendEmailAsync(sendGridMessage);
        }
    }
}
