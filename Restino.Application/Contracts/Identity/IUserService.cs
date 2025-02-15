using Restino.Application.DTOs;

namespace Restino.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<string> GetUserId();
        Task<GetUserDetailsResponse> GetUserDetailsAsync(string userId);
    }
}
