using AutoMapper;
using MediatR;
using Restino.Application.Contracts.Identity;
using Restino.Application.DTOs;

namespace Restino.Application.Features.Accounts.Queries.Authentication
{
    public class AuthenticationQueryHandler : IRequestHandler<AuthenticationQuery, AuthenticationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationQueryHandler(IMapper mapper, IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponse> Handle(AuthenticationQuery request, CancellationToken cancellationToken)
        {
            var authenticationRequest = new AuthenticationRequest
            {
                Email = request.Email,
                Password = request.Password
            };

            var authentication = await _authenticationService.AuthenticateAsync(authenticationRequest);

            var authenticationResponse = _mapper.Map<AuthenticationResponse>(authentication);

            return authenticationResponse;
        }
    }
}