using MediatR;
using Restino.Application.DTOs;

namespace Restino.Application.Features.Accounts.Commands.Registration
{
    public class RegistrationCommand : IRequest<RegistrationResponse>
    {
        public string UserId { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
