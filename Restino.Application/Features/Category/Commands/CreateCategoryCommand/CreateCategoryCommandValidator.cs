using FluentValidation;
using Restino.Application.Contracts.Persistance;

namespace Restino.Application.Features.Category.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(p => p.CategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");

            RuleFor(e => e)
                .MustAsync(CategoryNameUnique)
                .WithMessage("An category with the same name already exists");

        }

        private async Task<bool> CategoryNameUnique(CreateCategoryCommand e,
            CancellationToken cancellationToken)
        {
            return !(await _categoryRepository.IsCategoryNameUnique(e.CategoryName));
        }
    }
}
