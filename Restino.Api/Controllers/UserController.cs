using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restino.Application.DTOs;
using Restino.Application.Features.Accommodation.Commands.DeleteAccommodation;
using Restino.Application.Features.User.Commands;
using Restino.Application.Features.User.Queries.GetUserDetails;
using Restino.Application.Features.User.Queries.GetUserList;
using Restino.Application.Features.User.Queries.SearchUser;
using System.Security.Claims;

namespace Restino.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : Controller
    {
        [HttpGet("[action]/{UserName?}", Name = "SearchUser")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<SearchUserResponse>>> SearchUser(string? UserName)
        {
            var searchUserDeatailQuery = new SearchUserQuery { UserName = UserName };
            return Ok(await mediator.Send(searchUserDeatailQuery));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{userId}", Name = "GetById")]
        public async Task<ActionResult<GetUserDetailsResponse>> GetByIdAsync(string userId)
        {
            var dtos = await mediator.Send(new GetUserDetailsQuery() { UserId = userId });
            return Ok(dtos);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet(Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetUserDetailsResponse>>> GetAllUsers()
        {
            var dtos = await mediator.Send(new GetUserListQuery());
            return Ok(dtos);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]/{userId}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string userId)
        {
            var deleteUserCommand = new DeleteUserCommand() { UserId = userId };
            await mediator.Send(deleteUserCommand);
            return NoContent();
        }

    }
}
