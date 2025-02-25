using AutoMapper;
using MediatR;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Exceptions;
using Restino.Domain.Entities;

namespace Restino.Application.Features.Reservation.Commands.DeleteReservation
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Reservations> _reservationRepository;
        public DeleteReservationCommandHandler(IMapper mapper, IAsyncRepository<Reservations> reservationRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository; 
        }
        public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteReservationCommandValidator(_reservationRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);


            var reservationToDelete = await _reservationRepository.GetByIdAsync(request.ReservationId);
            await _reservationRepository.DeleteAsync(reservationToDelete);

            return Unit.Value;
        }
    }
}
