using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restino.Application.Features.Accommodation.Commands.CreateAccommodation;
using Restino.Application.Features.Accommodation.Commands.DeleteAccommodation;
using Restino.Application.Features.Accommodation.Commands.UpdateAccommodation;
using Restino.Application.Features.Accommodation.Queries.GetAccommodationDetails;
using Restino.Application.Features.Accommodation.Queries.GetAccommodationList;
using Restino.Application.Features.Accommodation.Queries.GetUserAccommodationList;
using Restino.Application.Features.Accommodation.Queries.SearchAccommodationList;

namespace Restino.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationController(IMediator mediator) : Controller
    {
        [HttpGet(Name = "GetAllAccommodations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<AccommodationListVm>>> GetAllAccommodations([FromQuery] bool isAccommodationHot)
        {
            var dtos = await mediator.Send(new GetAccommodationListQuery() { isAccommodationHot = isAccommodationHot });
            return Ok(dtos);
        }

        [Authorize]
        [HttpGet("[action]/{userId}", Name = "GetAllUserAccommodations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<AccommodationListVm>>> GetAllUserAccommodations(string? userId)
        {
            var dtos = await mediator.Send(new GetUserAccommodationListQuery() { UserId = userId });
            return Ok(dtos);
        }

        [HttpGet("{AccommodationId}", Name = "GetAccommodationById")]
        public async Task<ActionResult<AccommodationDetailsVm>> GetAccommodationById(Guid AccommodationId)
        {
            var getAccommodationDeatailQuery = new GetAccommodationDetailsQuery() { Id = AccommodationId };
            return Ok(await mediator.Send(getAccommodationDeatailQuery));
        }


        [HttpGet("[action]/{AccommodationName?}", Name = "SearchAccommodation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<SearchAccommodationListVm>>> SearchAccommodation(string? AccommodationName)
        {
            var searchAccommodationDeatailQuery = new SearchAccommodationListQuery { Name = AccommodationName };
            return Ok(await mediator.Send(searchAccommodationDeatailQuery));
        }

        [Authorize]
        [HttpPost(Name = "AddAccommodation")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAccommodationCommand createAccommodationCommand)
        {
            var response = await mediator.Send(createAccommodationCommand);
            return Ok(response);
        }

        [Authorize]
        [HttpPut(Name = "UpdateAccommdation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult> Update([FromBody] UpdateAccommodationCommand
            updateAccommodationCommand)
        {
            var response = await mediator.Send(updateAccommodationCommand);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}", Name = "DeleteAccommodation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteAccommodationCommand = new DeleteAccommodationCommand() { AccommodationsId = id };
            await mediator.Send(deleteAccommodationCommand);
            return NoContent();
        }
    }
}
