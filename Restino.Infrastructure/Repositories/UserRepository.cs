using Microsoft.AspNetCore.Identity;
using Restino.Application.Contracts.Infrastructure;
using Restino.Application.DTOs;

namespace Restino.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository()
        {
            
        }
        public Task<GetUserDetailsResponse> GetUserDetailsAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception($"User with not found.");
            }

            GetUserDetailsResponse response = new GetUserDetailsResponse
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName
            };

            return response;
        }

        public Task<string> GetUserId()
        {
            throw new NotImplementedException();
        }
    }
}
