using MediatR;

namespace Restino.Application.Features.Accommodation.Commands.DeleteAccommodation
{
    public class DeleteAccommodationCommand : IRequest
    {
        public Guid AccommodationsId { get; set; }
    }
}
