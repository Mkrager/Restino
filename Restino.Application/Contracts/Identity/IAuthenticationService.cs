using Restino.Application.DTOs;

namespace Restino.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest response);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest response);
    }
}
