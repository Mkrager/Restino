using AutoMapper;
using Moq;
using Restino.Appilcation.UnitTests.Mock;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Features.Accommodation.Queries.GetUserAccommodationList;
using Restino.Application.Profiles;
using Shouldly;

namespace Restino.Appilcation.UnitTests.Accommodation.Queries
{
    public class GetUserAccommodationListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAccommodationRepository> _mockAccommodationRepository;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public GetUserAccommodationListQueryHandlerTests()
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
        public async Task ListUserAccommodationListTest()
        {
            var handler = new GetUserAccommodationListQueryHandler(_mapper, _mockAccommodationRepository.Object, _mockCategoryRepository.Object);

            string userId = "12334556456745";

            var result = await handler.Handle(new GetUserAccommodationListQuery() { UserId = userId }, CancellationToken.None);

            result.ShouldBeOfType<List<UserAccommodationListVm>>();

            result.Count.ShouldBe(1);
        }

    }
}
