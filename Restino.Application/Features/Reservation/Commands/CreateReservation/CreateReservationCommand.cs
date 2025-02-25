using MediatR;

namespace Restino.Application.Features.Reservation.Commands.CreateReservation
{
    public class CreateReservationCommand : IRequest<Guid>
    {
        public Guid AccommodationsId { get; set; }
        public string AccommodationName { get; set; } = string.Empty;
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int GuestsCount { get; set; }
        public string AdditionalServices { get; set; } = string.Empty;
        public string CustomerNote { get; set; } = string.Empty;

    }
}
