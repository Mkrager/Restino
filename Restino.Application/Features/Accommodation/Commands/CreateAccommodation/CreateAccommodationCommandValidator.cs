using FluentValidation;
using Restino.Application.Contracts.Persistance;

namespace Restino.Application.Features.Accommodation.Commands.CreateAccommodation
{
    public class CreateAccommodationCommandValidator : AbstractValidator<CreateAccommodationCommand>
    {
        private readonly IAccommodationRepository _accommodationRepository;
        public CreateAccommodationCommandValidator(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(p => p.ShortDescription)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MinimumLength(10)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(p => p.LongDescription)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MinimumLength(10)
                .MaximumLength(650).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(p => p.Capacity)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0);

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0);

            RuleFor(e => e)
                .MustAsync(AccommodationNameAndCategoryUnique)
                .WithMessage("An accommodation with the same name and category already exists");
        }

        private async Task<bool> AccommodationNameAndCategoryUnique(CreateAccommodationCommand e,
            CancellationToken cancellationToken)
        {
            return !(await _accommodationRepository.IsAccommodationNameAndCategoryUnique(e.Name, e.CategoryId));
        }
    }
}
