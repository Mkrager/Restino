using FluentValidation;
using Restino.Application.Contracts.Persistance;
using Restino.Domain.Entities;

namespace Restino.Application.Features.Reservation.Commands.DeleteReservation
{
    public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
    {
        private readonly IAsyncRepository<Reservations> _reservationRepository;
        public DeleteReservationCommandValidator(IAsyncRepository<Reservations> reservationRepository)
        {
            _reservationRepository = reservationRepository;

            RuleFor(e => e)
                .MustAsync(CheckUserPermissionAsync)
                .WithMessage("Permission required");
        }
        private async Task<bool> CheckUserPermissionAsync(DeleteReservationCommand e,
            CancellationToken cancellationToken)
        {
            return await _reservationRepository.CheckUserPermissionAsync(e.UserId, e.ReservationId, e.UserRole);
        }
    }
}
