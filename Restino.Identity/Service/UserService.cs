using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Restino.Application.Contracts.Identity;
using Restino.Application.DTOs;
using Restino.Identity.Models;

namespace Restino.Identity.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<GetUserDetailsResponse> GetUserDetailsAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception($"User not found.");
            }

            GetUserDetailsResponse response = new GetUserDetailsResponse
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName
            };

            return response;
        }

        public Task<string> GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst("uid")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new Exception("User is not authenticated.");
            }

            return Task.FromResult(userId);
        }
    }
}
