using AutoMapper;
using Moq;
using Restino.Appilcation.UnitTests.Mock;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Features.Accommodation.Queries.GetAccommodationList;
using Restino.Application.Profiles;
using Shouldly;

namespace Restino.Appilcation.UnitTests.Accommodation.Queries
{
    public class GetAccommodationListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAccommodationRepository> _mockAccommodationRepository;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public GetAccommodationListQueryHandlerTests()
        {
            _mockAccommodationRepository = RepositoryMocks.GetAccommodationRepository();
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetAccommodationListTest_IsAccommodationHotNull()
        {
            bool? isAccommodationHot = null;
            var handler = new GetAccommodationListQueryHandler(_mapper, _mockAccommodationRepository.Object, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetAccommodationListQuery() { isAccommodationHot = isAccommodationHot.HasValue }, CancellationToken.None);

            result.ShouldBeOfType<List<AccommodationListVm>>();

            result.Count.ShouldBe(7);
        }

        [Fact]
        public async Task TaskGetAccommodationListTest_IsAccommodationHoTrue()
        {
            bool? isAccommodationHot = true;
            var handler = new GetAccommodationListQueryHandler(_mapper, _mockAccommodationRepository.Object, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetAccommodationListQuery() { isAccommodationHot = isAccommodationHot.HasValue }, CancellationToken.None);

            result.ShouldBeOfType<List<AccommodationListVm>>();

            result.Count.ShouldBe(4);
        }
    }
}
