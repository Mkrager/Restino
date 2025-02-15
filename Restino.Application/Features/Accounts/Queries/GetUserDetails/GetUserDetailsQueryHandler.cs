using AutoMapper;
using MediatR;
using Restino.Application.Contracts.Identity;
using Restino.Application.DTOs;

namespace Restino.Application.Features.Accounts.Queries.GetById
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, GetUserDetailsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userRepository;
        public GetUserDetailsQueryHandler(IMapper mapper, IUserService userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserDetailsResponse> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserDetailsAsync(request.UserId);
            return _mapper.Map<GetUserDetailsResponse>(user);
        }
    }
}
