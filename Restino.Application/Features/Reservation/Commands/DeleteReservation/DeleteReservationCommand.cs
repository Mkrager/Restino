using MediatR;

namespace Restino.Application.Features.Reservation.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest
    {
        public Guid ReservationId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string UserRole {  get; set; } = string.Empty;
    }
}
