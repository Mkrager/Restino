using AutoMapper;
using Moq;
using Restino.Appilcation.UnitTests.Mock;
using Restino.Application.Contracts.Identity;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Exceptions;
using Restino.Application.Features.Reservation.Commands.CreateReservation;
using Restino.Application.Profiles;
using Shouldly;

namespace Restino.Appilcation.UnitTests.Reservation.Commands
{
    public class CreateReservationCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IReservationRepository> _mockReservationRepository;
        private readonly Mock<IUserService> _mockUserService;

        public CreateReservationCommandTests()
        {
            _mockReservationRepository = RepositoryMocks.GetReservationRepository();
            _mockUserService = RepositoryMocks.GetUserService();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Should_Create_Reservation_Successfully()
        {
            // Arrange
            var handler = new CreateReservationCommandHandler(_mapper, _mockReservationRepository.Object, _mockUserService.Object);
            var command = new CreateReservationCommand
            {
                AccommodationsId = Guid.Parse("6a4ab6df-66b8-46f7-8198-c94332964006"),
                AdditionalServices = "test",
                CustomerNote = "test",
                GuestsCount = 1,
                CheckInDate = DateTime.Today,
                CheckOutDate = DateTime.Today.AddDays(42)
            };

            // Act
            await handler.Handle(command, CancellationToken.None);


            // Assert
            var allReservation = await _mockReservationRepository.Object.ListAllAsync();
            allReservation.Count.ShouldBe(2);

            var createdReservation = allReservation.LastOrDefault();
            createdReservation.ShouldNotBeNull();
            createdReservation.AccommodationsId.ShouldBe(command.AccommodationsId);
            createdReservation.AdditionalServices.ShouldBe(command.AdditionalServices);
            createdReservation.CustomerNote.ShouldBe(command.CustomerNote);
            createdReservation.GuestsCount.ShouldBe(command.GuestsCount);
            createdReservation.CheckInDate.ShouldBe(command.CheckInDate);
            createdReservation.CheckOutDate.ShouldBe(command.CheckOutDate);
        }

        [Fact]
        public async Task Should_FailToCreateReservation_WhenDateRangesOverlap()
        {
            // Arrange
            var handler = new CreateReservationCommandHandler(_mapper, _mockReservationRepository.Object, _mockUserService.Object);
            var command = new CreateReservationCommand
            {
                AccommodationsId = Guid.Parse("1a4ab6df-66b8-46f7-8198-c94332964001"),
                AdditionalServices = "test",
                CustomerNote = "test",
                GuestsCount = 1,
                CheckInDate = DateTime.Today,
                CheckOutDate = DateTime.Today.AddDays(42)
            };

            // Act
            var exception = await Assert.ThrowsAsync<ValidationException>(async () =>
                await handler.Handle(command, CancellationToken.None)
            );

            // Assert
            exception.ValidationErrors.ShouldContain("Invalid date range");

            var allReservation = await _mockReservationRepository.Object.ListAllAsync();
            allReservation.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_FailToCreateReservation_WhenInvalidGuestCount()
        {
            // Arrange
            var handler = new CreateReservationCommandHandler(_mapper, _mockReservationRepository.Object, _mockUserService.Object);
            var command = new CreateReservationCommand
            {
                AccommodationsId = Guid.Parse("6a4ab6df-66b8-46f7-8198-c94332964006"),
                AdditionalServices = "test",
                CustomerNote = "test",
                GuestsCount = 42,  
                CheckInDate = DateTime.Today,
                CheckOutDate = DateTime.Today.AddDays(42)
            };

            // Act
            var exception = await Assert.ThrowsAsync<ValidationException>(async () =>
                await handler.Handle(command, CancellationToken.None)
            );

            // Assert
            exception.ValidationErrors.ShouldContain("Guest count exceeds accommodation capacity");

            var allReservation = await _mockReservationRepository.Object.ListAllAsync();
            allReservation.Count.ShouldBe(1);

        }
    }
}
