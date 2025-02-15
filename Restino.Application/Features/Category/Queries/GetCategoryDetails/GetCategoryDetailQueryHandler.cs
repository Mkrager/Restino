using AutoMapper;
using MediatR;
using Restino.Application.Contracts.Persistance;
using Restino.Domain.Entities;

namespace Restino.Application.Features.Category.Queries.GetCategoryDetails
{
    public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQuery, CategoryDetailsVm>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Categories> _categoryRepository;

        public GetCategoryDetailQueryHandler(IMapper mapper, IAsyncRepository<Categories> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDetailsVm> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoriesId);
            return _mapper.Map<CategoryDetailsVm>(category);
        }
    }
}
