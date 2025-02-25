using MediatR;
using Restino.Application.Contracts.Persistance;
using Restino.Domain.Entities;
using AutoMapper;

namespace Restino.Application.Features.Accommodation.Queries.GetAccommodationList
{
    public class GetAccommodationListQueryHandler : IRequestHandler
        <GetAccommodationListQuery, List<AccommodationListVm>>
    {
        private readonly IAsyncRepository<Categories> _categoryRepository;
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly IMapper _mapper;

        public GetAccommodationListQueryHandler(IMapper mapper, IAccommodationRepository accommodationRepository, IAsyncRepository<Categories> categoryRepository)
        {
            _mapper = mapper;
            _accommodationRepository = accommodationRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<AccommodationListVm>> Handle(GetAccommodationListQuery request, CancellationToken cancellationToken)
        {
            var accommodations = await _accommodationRepository.ListAllAccommodations(request.isAccommodationHot);
            var accommodationDetailsDto = _mapper.Map<List<AccommodationListVm>>(accommodations);

            var categories = await _categoryRepository.ListAllAsync();
            foreach (var accommodation in accommodationDetailsDto)
            {
                accommodation.Category = _mapper.Map<CategoryDtoAccommodation>(categories.FirstOrDefault(c => c.CategoriesId == accommodation.CategoryId));
            }
            return accommodationDetailsDto;
        }
    }
}


