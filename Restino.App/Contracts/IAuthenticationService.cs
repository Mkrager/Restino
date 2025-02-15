using Restino.App.Services;
using Restino.App.ViewModels;

namespace Restino.App.Contracts
{
    public interface IAuthenticationService
    {
        Task<ApiResponse<bool>> Authenticate(string email, string password);
        Task<ApiResponse<bool>> Register(string firstName, string lastName, string userName, string email, string password);
        Task<AccountViewModel> GetAccountDetails(string UserId);
        Task Logout();
        string GetAccessToken();
    }
}
