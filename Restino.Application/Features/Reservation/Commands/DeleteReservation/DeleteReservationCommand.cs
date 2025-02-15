using MediatR;

namespace Restino.Application.Features.Reservation.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest
    {
        public Guid ReservationId { get; set; }
    }
}
