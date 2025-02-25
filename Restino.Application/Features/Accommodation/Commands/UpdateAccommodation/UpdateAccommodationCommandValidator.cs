using FluentValidation;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Features.Accommodation.Commands.DeleteAccommodation;

namespace Restino.Application.Features.Accommodation.Commands.UpdateAccommodation
{
    public class UpdateAccommodationCommandValidator : AbstractValidator<UpdateAccommodationCommand>
    {
        private readonly IAccommodationRepository _accommodationRepository;
        public UpdateAccommodationCommandValidator(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

            RuleFor(e => e)
                .MustAsync(AccommodationNameAndCategoryUnique)
                .WithMessage("An accommodation with the same name and date already exists");
            RuleFor(e => e)
                .MustAsync(CheckUserPermissionAsync)
                .WithMessage("Permission required");

        }

        private async Task<bool> AccommodationNameAndCategoryUnique(UpdateAccommodationCommand e,
            CancellationToken cancellationToken)
        {
            return !(await _accommodationRepository.IsAccommodationNameAndCategoryUniqueUpdate(e.Name, e.CategoryId, e.AccommodationsId));
        }
        private async Task<bool> CheckUserPermissionAsync(UpdateAccommodationCommand e,
            CancellationToken cancellationToken)
        {
            return await _accommodationRepository.CheckUserPermissionAsync(e.UserId, e.AccommodationsId, e.UserRole);
        }

    }
}
