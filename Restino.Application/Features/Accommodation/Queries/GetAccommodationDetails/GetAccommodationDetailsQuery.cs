using MediatR;

namespace Restino.Application.Features.Accommodation.Queries.GetAccommodationDetails
{
    public class GetAccommodationDetailsQuery : IRequest<AccommodationDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
