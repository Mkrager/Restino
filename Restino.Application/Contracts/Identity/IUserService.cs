using Restino.Application.DTOs;

namespace Restino.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<string> GetUserId();
        Task<GetUserDetailsResponse> GetUserDetailsAsync(string userId);
        Task<List<GetUserDetailsResponse>> GetUserListAsync();
        Task<string> GetUserRole();
        Task<List<SearchUserResponse>> SearchUser(string searchInput);
        Task DeleteUser(string userId);
    }
}
