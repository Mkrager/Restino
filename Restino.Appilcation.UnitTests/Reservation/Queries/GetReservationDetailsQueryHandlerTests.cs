using AutoMapper;
using Moq;
using Restino.Appilcation.UnitTests.Mock;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Features.Accommodation.Queries.GetAccommodationDetails;
using Restino.Application.Features.Reservation.Queries.GetReservatioDetails;
using Restino.Application.Features.Reservation.Queries.GetReservationList;
using Restino.Application.Profiles;
using Restino.Domain.Entities;
using Shouldly;

namespace Restino.Appilcation.UnitTests.Reservation.Queries
{
    public class GetReservationDetailsQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IReservationRepository> _mockReservationRepository;

        public GetReservationDetailsQueryHandlerTests()
        {
            _mockReservationRepository = RepositoryMocks.GetReservationRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetReservationDetailsTest()
        {
            var handler = new GetReservationDetailQueryHandler(_mapper, _mockReservationRepository.Object);

            var result = await handler.Handle(new GetReservationDetailQuery() { ReservationId = Guid.Parse("7a4ab6df-66b8-55f7-6698-c94332964007") }, CancellationToken.None);

            result.ShouldBeOfType<ReservationDetailsVm>();

            result.ReservationId.ShouldBe(Guid.Parse("7a4ab6df-66b8-55f7-6698-c94332964007"));
            result.AccommodationsId.ShouldBe(Guid.Parse("1a4ab6df-66b8-46f7-8198-c94332964001"));
            result.AdditionalServices.ShouldBe("test");
            result.CustomerNote.ShouldBe("test");
            result.GuestsCount.ShouldBe(1);
            result.CheckInDate.ShouldBe(DateTime.Today);
            result.CheckOutDate.ShouldBe(DateTime.Today.AddDays(42));
        }

    }
}
