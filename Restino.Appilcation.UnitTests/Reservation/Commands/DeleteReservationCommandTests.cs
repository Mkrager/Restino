using AutoMapper;
using Moq;
using Restino.Appilcation.UnitTests.Mock;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Features.Accommodation.Commands.DeleteAccommodation;
using Restino.Application.Features.Reservation.Commands.DeleteReservation;
using Restino.Application.Profiles;
using Shouldly;

namespace Restino.Appilcation.UnitTests.Reservation.Commands
{
    public class DeleteReservationCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IReservationRepository> _mockReservationRepository;

        public DeleteReservationCommandTests()
        {
            _mockReservationRepository = RepositoryMocks.GetReservationRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Delete_Reservation_RemovesAccommodationFromRepo()
        {
            var handler = new DeleteReservationCommandHandler(_mapper, _mockReservationRepository.Object);
            await handler.Handle(new DeleteReservationCommand() { ReservationId = Guid.Parse("7a4ab6df-66b8-55f7-6698-c94332964007"), UserRole = "Admin" }, CancellationToken.None);

            var allAccommodations = await _mockReservationRepository.Object.ListAllAsync();
            allAccommodations.Count.ShouldBe(0);
        }

    }
}
