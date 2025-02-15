using AutoMapper;
using MediatR;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Exceptions;
using Restino.Domain.Entities;

namespace Restino.Application.Features.Accommodation.Queries.SearchAccommodationList
{
    public class SearchAccommodationListQueryHandler : IRequestHandler<SearchAccommodationListQuery, List<SearchAccommodationListVm>>
    {
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Categories> _categoryRepository;

        public SearchAccommodationListQueryHandler(IAccommodationRepository accommodationRepository, IMapper mapper, IAsyncRepository<Categories> categoryRepository)
        {
            _accommodationRepository = accommodationRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<SearchAccommodationListVm>> Handle(SearchAccommodationListQuery request, CancellationToken cancellationToken)
        {
            var validator = new SearchAccommodationQueryValidator(_accommodationRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            var searchResult = await _accommodationRepository.SearchAccommodation(request.Name);
            var mappedSearchResult = _mapper.Map<List<SearchAccommodationListVm>>(searchResult);
            var categories = await _categoryRepository.ListAllAsync();

            foreach (var searchResults in mappedSearchResult)
            {
                searchResults.Category = _mapper.Map<CategoryDtoAccommodationSearch>(categories.FirstOrDefault(c => c.CategoriesId == searchResults.CategoryId));
            }

            return mappedSearchResult;
        }
    }
}
