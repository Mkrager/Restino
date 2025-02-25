using MediatR;
using Restino.Application.Contracts.Identity;
using Restino.Application.DTOs;

namespace Restino.Application.Features.User.Queries.SearchUser
{
    public class SearchUserQueryHandler : IRequestHandler<SearchUserQuery, List<SearchUserResponse>>
    {
        private readonly IUserService _userRepository;
        public SearchUserQueryHandler(IUserService userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<SearchUserResponse>> Handle(SearchUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.SearchUser(request.UserName);
            return users;
        }
    }
}
