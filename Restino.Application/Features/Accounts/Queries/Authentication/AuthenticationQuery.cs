using MediatR;
using Restino.Application.DTOs;

namespace Restino.Application.Features.Accounts.Queries.Authentication
{
    public class AuthenticationQuery : IRequest<AuthenticationResponse>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
