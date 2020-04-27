using System.Threading.Tasks;
using TRMDesktopUI.Models;

namespace TRMDesktopUI.Helper
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string userName, string password);
        Task GetLoggedInUserInfo(string token);
    }
}