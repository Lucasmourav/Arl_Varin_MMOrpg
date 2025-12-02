using System.Threading.Tasks;
using Mmorpg.Web.Models;

namespace Mmorpg.Web.Services
{
    public interface IAuthService
    {
        Task<(bool Success, string Message, SupabaseUser User)> RegisterAsync(string email, string password, string username);
        Task<(bool Success, string Message, SupabaseUser User)> LoginAsync(string email, string password);
        Task LogoutAsync();
        Task<SupabaseUser> GetCurrentUserAsync();
        Task<bool> IsUserAuthenticatedAsync();
    }
}
