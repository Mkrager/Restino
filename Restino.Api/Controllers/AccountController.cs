using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restino.Application.DTOs;
using Restino.Application.Features.Accounts.Commands.Registration;
using Restino.Application.Features.Accounts.Queries.Authentication;

namespace Restino.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IMediator mediator) : Controller
    {
        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            var dtos = await mediator.Send(new AuthenticationQuery() 
            { 
                Email = request.Email, 
                Password = request.Password 
            });

            return Ok(dtos);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            var dtos = await mediator.Send(new RegistrationCommand() 
            { 
                UserName = request.UserName, 
                Password = request.Password, 
                Email = request.Email, 
                FirstName = request.FirstName, 
                LastName = request.LastName 
            });

            return Ok(dtos);
        }
    }
}
