using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restino.Application.Features.Accommodation.Queries.GetUserAccommodationList;
using Restino.Application.Features.Reservation.Commands.CreateReservation;
using Restino.Application.Features.Reservation.Commands.DeleteReservation;
using Restino.Application.Features.Reservation.Queries.GetReservatioDetails;
using Restino.Application.Features.Reservation.Queries.GetReservationList;
using Restino.Application.Features.Reservation.Queries.GetUserReservations;
using System.Security.Claims;

namespace Restino.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController(IMediator mediator) : Controller
    {
        //[Authorize(Roles = "Admin")]
        [Authorize]
        [HttpGet(Name = "GetAllReservation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ReservationListVm>>> GetAllReservations()
        {
            var dtos = await mediator.Send(new GetReservationListQuery());
            return Ok(dtos);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{ReservationsId}", Name = "GetReservationById")]
        public async Task<ActionResult<ReservationDetailsVm>> GetReservationById(Guid ReservationsId)
        {
            var getReservationDetailsQuery = new GetReservationDetailQuery() { ReservationId = ReservationsId };
            return Ok(await mediator.Send(getReservationDetailsQuery));
        }

        [Authorize]
        [HttpPost(Name = "AddReservation")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateReservationCommand createReservationCommand)
        {
            var response = await mediator.Send(createReservationCommand);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}", Name = "DeleteReservation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var userId = User.FindFirst("uid")?.Value;
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var deleteReservationCommand = new DeleteReservationCommand() { ReservationId = id, UserId = userId, UserRole = userRole };
            await mediator.Send(deleteReservationCommand);
            return NoContent();
        }

        [Authorize]
        [HttpGet("[action]/{userId}", Name = "GetUserReservations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetUserReservationListVm>>> GetUserReservations(string userId)
        {
            var dtos = await mediator.Send(new GetUserReservationListQuery { UserId = userId });
            return Ok(dtos);
        }

    }
}
