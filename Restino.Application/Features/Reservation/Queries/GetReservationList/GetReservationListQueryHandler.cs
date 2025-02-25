using AutoMapper;
using MediatR;
using Restino.Application.Contracts.Persistance;
using Restino.Domain.Entities;

namespace Restino.Application.Features.Reservation.Queries.GetReservationList
{
    public class GetReservationListQueryHandler
        : IRequestHandler<GetReservationListQuery, List<ReservationListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Reservations> _reservationRepository;
        public GetReservationListQueryHandler(IMapper mapper, IAsyncRepository<Reservations> reservationRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
        }
        public async Task<List<ReservationListVm>> Handle(GetReservationListQuery request, CancellationToken cancellationToken)
        {
            var allReservation = (await _reservationRepository.ListAllAsync()).OrderBy(x => x.UserId);
            return _mapper.Map<List<ReservationListVm>>(allReservation);
        }
    }
}
