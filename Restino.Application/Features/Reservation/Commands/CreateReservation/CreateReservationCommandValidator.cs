using FluentValidation;
using Restino.Application.Contracts.Persistance;

namespace Restino.Application.Features.Reservation.Commands.CreateReservation
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        private readonly IReservationRepository _reservationRepository;

        public CreateReservationCommandValidator(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;

            RuleFor(e => e.GuestsCount)
                .NotEmpty().WithMessage("{PropertyName} must be greater than 0")
                .GreaterThan(0).WithMessage("{PropertyName} must be a positive number");

            RuleFor(e => e.CustomerNote)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(e => e)
                .MustAsync(GuestsCountMustBeWithinCapacity)
                .WithMessage("Guest count exceeds accommodation capacity");

            RuleFor(e => e)
                .MustAsync(DateRangeValid)
                .WithMessage("Invalid date range");
        }

        private async Task<bool> GuestsCountMustBeWithinCapacity(CreateReservationCommand e, CancellationToken cancellationToken)
        {
            return !(await _reservationRepository.IsGuestsCountWithinCapacity(e.GuestsCount, e.AccommodationsId));
        }

        private async Task<bool> DateRangeValid(CreateReservationCommand e, CancellationToken cancellationToken)
        {
            return !(await _reservationRepository.IsDateRangeValid(e.CheckInDate, e.CheckOutDate, e.AccommodationsId));
        }
    }
}
