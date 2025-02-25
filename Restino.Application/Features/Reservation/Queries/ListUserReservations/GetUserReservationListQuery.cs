using MediatR;

namespace Restino.Application.Features.Reservation.Queries.GetUserReservations
{
    public class GetUserReservationListQuery : IRequest<List<GetUserReservationListVm>>
    {
        public string UserId { get; set; } = string.Empty;
    }
}
