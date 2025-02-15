using AutoMapper;
using MediatR;
using Restino.Application.Contracts.Identity;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Exceptions;
using Restino.Domain.Entities;

namespace Restino.Application.Features.Reservation.Commands.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly IUserService _userService;

        public CreateReservationCommandHandler(IMapper mapper, IReservationRepository reservationRepository, IUserService userService)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _userService = userService;
        }

        public async Task<Guid> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateReservationCommandValidator(_reservationRepository);

            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            var reservation = new Reservations()
            {
                AccommodationsId = request.AccommodationsId,
                AdditionalServices = request.AdditionalServices,
                CheckInDate = request.CheckInDate,
                CheckOutDate = request.CheckOutDate,
                CustomerNote = request.CustomerNote,
                GuestsCount = request.GuestsCount,
                UserId = await _userService.GetUserId(),
                ReservationPrice = await _reservationRepository.TotalPrice(request.AccommodationsId, request.CheckInDate, request.CheckOutDate),
            };

            reservation = await _reservationRepository.AddAsync(reservation);

            reservation = _mapper.Map<Reservations>(reservation);

            return reservation.ReservationId;
        }
    }
}

