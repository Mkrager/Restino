using FluentValidation;
using Restino.Application.Contracts.Persistance;
using Restino.Domain.Entities;

namespace Restino.Application.Features.Accommodation.Commands.DeleteAccommodation
{
    public class DeleteAccommodationCommandValidator : AbstractValidator<DeleteAccommodationCommand>
    {
        private readonly IAsyncRepository<Accommodations> _accommodationRepository;
        public DeleteAccommodationCommandValidator(IAsyncRepository<Accommodations> accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;

            RuleFor(e => e)
                .MustAsync(CheckUserPermissionAsync)
                .WithMessage("Permission required");
        }

        private async Task<bool> CheckUserPermissionAsync(DeleteAccommodationCommand e,
            CancellationToken cancellationToken)
        {
            return await _accommodationRepository.CheckUserPermissionAsync(e.UserId, e.AccommodationsId, e.UserRole);
        }
    }
}
