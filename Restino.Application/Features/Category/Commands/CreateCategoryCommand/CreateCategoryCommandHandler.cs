using AutoMapper;
using MediatR;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Exceptions;
using Restino.Domain.Entities;

namespace Restino.Application.Features.Category.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validation = new CreateCategoryCommandValidator(_categoryRepository);
            var validationResult = await validation.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var category = new Categories() 
            { 
                CategoryName = request.CategoryName, 
                Description = request.Description, 
                ImgUrl = request.ImgUrl 
            };

            await _categoryRepository.AddAsync(category);

            category = _mapper.Map<Categories>(category);

            return category.CategoriesId;
        }
    }
}
