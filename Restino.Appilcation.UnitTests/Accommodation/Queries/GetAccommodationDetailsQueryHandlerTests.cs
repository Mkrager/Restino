using AutoMapper;
using Moq;
using Restino.Appilcation.UnitTests.Mock;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Features.Accommodation.Queries.GetAccommodationDetails;
using Restino.Application.Profiles;
using Shouldly;

namespace Restino.Appilcation.UnitTests.Accommodation.Queries
{
    public class GetAccommodationDetailsQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAccommodationRepository> _mockAccommodationRepository;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public GetAccommodationDetailsQueryHandlerTests()
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
        public async Task GetAccommodationDetails_ReturnsCorrectAccommodationDetails()
        {
            var handler = new GetAccommodationDetailsQueryHandler(_mapper, _mockAccommodationRepository.Object, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetAccommodationDetailsQuery() { Id = Guid.Parse("1a4ab6df-66b8-46f7-8198-c94332964001") }, CancellationToken.None);

            result.ShouldBeOfType<AccommodationDetailsVm>();

            result.AccommodationsId.ShouldBe(Guid.Parse("1a4ab6df-66b8-46f7-8198-c94332964001"));
            result.Name.ShouldBe("City View Apartment");
            result.Address.ShouldBe("101 Central St, Cityville");
            result.Capacity.ShouldBe(4);
            result.CreatedDate.ShouldBe(DateTime.Today.AddDays(20).Date);
            result.CategoryId.ShouldBe(Guid.Parse("c119661c-1d5a-42c1-8819-6b0885af4d4a"));
            result.ShortDescription.ShouldBe("A modern apartment with a city view.");
            result.ImgUrl.ShouldBe("https://cdn.pixabay.com/photo/2015/09/05/21/51/room-924058_1280.jpg");
            result.Price.ShouldBe(7000);
        }


    }
}
