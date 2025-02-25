using Microsoft.EntityFrameworkCore;
using Restino.Domain.Entities;
using Restino.Persistence.Repositories;

namespace Restino.Persistence.IntegrationTests.ReservationTests
{
    public class ReservationRepositoryTests
    {
        private readonly RestinoDbContext _dbContext;
        private readonly ReservationRepository _repository;

        public ReservationRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<RestinoDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _dbContext = new RestinoDbContext(options);
            _repository = new ReservationRepository(_dbContext);
        }

        [Fact]
        public async Task IsDateRangeValid_ShouldReturnTrue_WhenCheckInDateIsGreaterThanCheckOutDate()
        {
            // Arrange
            var checkInDate = DateTime.Today.AddDays(2);
            var checkOutDate = DateTime.Today.AddDays(1);
            var accommodationId = Guid.NewGuid();

            // Act
            var result = await _repository.IsDateRangeValid(checkInDate, checkOutDate, accommodationId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task IsDateRangeValid_ShouldReturnTrue_WhenCheckInDateIsBeforeCurrentDate()
        {
            // Arrange
            var checkInDate = DateTime.Today.AddDays(-2);
            var checkOutDate = DateTime.Today.AddDays(3);
            var accommodationId = Guid.NewGuid();

            // Act
            var result = await _repository.IsDateRangeValid(checkInDate, checkOutDate, accommodationId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task IsDateRangeValid_ShouldReturnTrue_WhenCheckInDateIsMoreThanOneYearAhead()
        {
            // Arrange
            var checkInDate = DateTime.Today.AddYears(2);
            var checkOutDate = DateTime.Today.AddYears(2).AddDays(3);
            var accommodationId = Guid.NewGuid();

            // Act
            var result = await _repository.IsDateRangeValid(checkInDate, checkOutDate, accommodationId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task IsDateRangeValid_ShouldReturnFalse_WhenDatesOverlapWithExistingReservation()
        {
            // Arrange
            var checkInDate = DateTime.Today.AddDays(3);
            var checkOutDate = DateTime.Today.AddDays(7);
            var accommodationId = Guid.NewGuid();

            _dbContext.Reservation.Add(new Reservations
            {
                ReservationId = Guid.NewGuid(),
                AccommodationsId = accommodationId,
                CheckInDate = DateTime.Today.AddDays(8),
                CheckOutDate = DateTime.Today.AddDays(11),
                GuestsCount = 2
            });
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _repository.IsDateRangeValid(checkInDate, checkOutDate, accommodationId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task IsGuestsCountWithinCapacity_ShouldReturnTrue_WhenGuestsCountExceedsCapacity()
        {
            // Arrange
            var accommodationId = Guid.NewGuid();
            var accommodation = new Accommodations
            {
                AccommodationsId = accommodationId,
                Capacity = 2
            };
            _dbContext.Accommodations.Add(accommodation);
            await _dbContext.SaveChangesAsync();
            var guestsCount = 3;

            // Act
            var result = await _repository.IsGuestsCountWithinCapacity(guestsCount, accommodationId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task IsGuestsCountWithinCapacity_ShouldReturnFalse_WhenGuestsCountDoesNotExceedCapacity()
        {
            // Arrange
            var accommodationId = Guid.NewGuid();
            var accommodation = new Accommodations
            {
                AccommodationsId = accommodationId,
                Capacity = 2
            };
            _dbContext.Accommodations.Add(accommodation);
            await _dbContext.SaveChangesAsync();
            var guestsCount = 2;

            // Act
            var result = await _repository.IsGuestsCountWithinCapacity(guestsCount, accommodationId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task TotalPrice_ShouldReturnCorrectTotalPrice()
        {
            // Arrange
            var accommodationId = Guid.NewGuid();
            var accommodation = new Accommodations
            {
                AccommodationsId = accommodationId,
                Price = 100
            };
            _dbContext.Accommodations.Add(accommodation);
            await _dbContext.SaveChangesAsync();

            var checkInDate = DateTime.Today;
            var checkOutDate = DateTime.Today.AddDays(3);

            // Act
            var result = await _repository.TotalPrice(accommodationId, checkInDate, checkOutDate);

            // Assert
            Assert.Equal(300, result);
        }

        [Fact]
        public async Task ListUserReservation_ShouldReturnUserReservations()
        {
            string userId = "123456789";
            // Arrange
            _dbContext.Reservation.AddRange(new List<Reservations>
            {
                new Reservations
                {
                    UserId = userId,
                    ReservationId = Guid.NewGuid(),
                    AccommodationsId = Guid.NewGuid(),         
                }
 
            });
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _repository.ListUserReservations(userId);

            // Assert
            Assert.Equal(1, result.Count);
            Assert.Contains(result, a => a.UserId == userId);
        }
    }
}
