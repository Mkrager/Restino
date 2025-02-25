using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public Task<string> GetUserRole()
        {
            var userRole = _httpContextAccessor.HttpContext?.User?.FindFirst("roles")?.Value;

            if (string.IsNullOrEmpty(userRole))
            {
                throw new Exception("User is not authenticated.");
            }

            return Task.FromResult(userRole);
        }

        public async Task<List<SearchUserResponse>> SearchUser(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                throw new ArgumentException("Search input cannot be empty.");
            }

            var users = await _userManager.Users
                .Where(u => u.UserName.Contains(searchInput) || u.Id.Equals(searchInput))
                .ToListAsync();

            var response = users.Select(user => new SearchUserResponse
            {
                UserId = user.Id,
                UserName = user.UserName,
            }).ToList();

            return response;
        }

        public async Task<List<GetUserDetailsResponse>> GetUserListAsync()
        {
            var users = _userManager.Users.ToList();

            var userDetailsList = users.Select(user => new GetUserDetailsResponse
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email
            }).ToList();

            return userDetailsList;
        }

        public async Task DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var result = await _userManager.DeleteAsync(user);
        }
    }
}
