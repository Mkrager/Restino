using AutoMapper;
using Moq;
using Restino.Appilcation.UnitTests.Mock;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Features.Reservation.Queries.GetReservationList;
using Restino.Application.Profiles;
using Shouldly;

namespace Restino.Appilcation.UnitTests.Reservation.Queries
{
    public class GetReservationListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IReservationRepository> _mockReservationRepository;

        public GetReservationListQueryHandlerTests()
        {
            _mockReservationRepository = RepositoryMocks.GetReservationRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetReservationListTest()
        {
            var handler = new GetReservationListQueryHandler(_mapper, _mockReservationRepository.Object);

            var result = await handler.Handle(new GetReservationListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<ReservationListVm>>();

            result.Count.ShouldBe(1);
        }
    }
}
