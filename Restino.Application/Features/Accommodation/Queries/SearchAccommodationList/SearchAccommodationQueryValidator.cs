using FluentValidation;
using Restino.Application.Contracts.Persistance;

namespace Restino.Application.Features.Accommodation.Queries.SearchAccommodationList
{
    public class SearchAccommodationQueryValidator : AbstractValidator<SearchAccommodationListQuery>
    {
        private readonly IAccommodationRepository _accommodationRepository;
        public SearchAccommodationQueryValidator(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
            RuleFor(a => a.Name)
            .NotNull()
            .WithMessage("Accommodation name must not be empty.")
            .NotEmpty()
            .WithMessage("Accommodation name must not be empty.")
            .MinimumLength(3)
            .WithMessage("Accommodation name must be at least 3 characters long.");
        }
    }
}
