using MediatR;

namespace Restino.Application.Features.Reservation.Queries.GetReservationList
{
    public class GetReservationListQuery : IRequest<List<ReservationListVm>>
    {        
    }
}
