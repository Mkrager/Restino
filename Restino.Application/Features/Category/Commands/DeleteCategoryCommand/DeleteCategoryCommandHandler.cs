using AutoMapper;
using MediatR;
using Restino.Application.Contracts.Persistance;
using Restino.Domain.Entities;

namespace Restino.Application.Features.Category.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Categories> _categoryRepository;

        public DeleteCategoryCommandHandler(IMapper mapper, IAsyncRepository<Categories> categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _categoryRepository.GetByIdAsync(request.CategoriesId);

            await _categoryRepository.DeleteAsync(categoryToDelete);

            return Unit.Value;
        }
    }
}
