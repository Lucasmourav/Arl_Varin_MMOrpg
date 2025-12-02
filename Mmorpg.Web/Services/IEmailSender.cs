using System.Threading.Tasks;

namespace Mmorpg.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
