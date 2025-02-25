using MediatR;

namespace Restino.Application.Features.Accommodation.Commands.DeleteAccommodation
{
    public class DeleteAccommodationCommand : IRequest
    {
        public Guid AccommodationsId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string UserRole {  get; set; } = string.Empty;
    }
}
