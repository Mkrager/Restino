using MediatR;

namespace Restino.Application.Features.Reservation.Queries.GetReservatioDetails
{
    public class GetReservationDetailQuery : IRequest<ReservationDetailsVm>
    {
        public Guid ReservationId { get; set; }
    }
}
