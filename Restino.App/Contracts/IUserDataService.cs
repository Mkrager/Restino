using Restino.App.Services;
using Restino.App.ViewModels;

namespace Restino.App.Contracts
{
    public interface IUserDataService
    {
        Task<GetUserDetailsResponse> GetUserDetails(string userId);
        Task<List<GetUserDetailsResponse>> GetUserList();
        Task<List<SearchUserResponse>> SearchUser(string searchInput);
        Task<ApiResponse<string>> DeleteUser(string id);
    }
}
