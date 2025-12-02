using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Mmorpg.Web.Settings;

namespace Mmorpg.Web.Services
{
    public class EmailSender : Mmorpg.Web.Services.IEmailSender
    {
        private readonly EmailSettings _settings;

        public EmailSender(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            if (string.IsNullOrWhiteSpace(_settings.Host) || string.IsNullOrWhiteSpace(_settings.FromAddress))
            {
                return;
            }

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_settings.FromName, _settings.FromAddress));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = htmlMessage };
            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(_settings.Host, _settings.Port, _settings.UseSsl ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.StartTlsWhenAvailable);

            if (!string.IsNullOrWhiteSpace(_settings.Username))
            {
                await client.AuthenticateAsync(_settings.Username, _settings.Password);
            }

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
