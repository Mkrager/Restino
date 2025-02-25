using Microsoft.EntityFrameworkCore;
using Restino.Domain.Entities;

namespace Restino.Persistence.IntegrationTests.RestinoDbContextTests
{
    public class RestinoDbContextTests
    {
        private readonly RestinoDbContext _dbContext;
        public RestinoDbContextTests()
        {
            var options = new DbContextOptionsBuilder<RestinoDbContext>()
            .UseInMemoryDatabase("TestDatabase")
                .Options;

            _dbContext = new RestinoDbContext(options);
        }

        [Fact]
        public async Task SaveChangesAsync_ShouldSetCreatedDate_WhenEntityIsAdded()
        {
            var accommodation = new Accommodations { Name = "New Accommodation" };

            _dbContext.Accommodations.Add(accommodation);
            await _dbContext.SaveChangesAsync();

            var savedAccommodation = await _dbContext.Accommodations.FindAsync(accommodation.AccommodationsId);

            Assert.NotNull(savedAccommodation);
            Assert.NotEqual(DateTime.MinValue, savedAccommodation.CreatedDate);
        }

        [Fact]
        public async Task SaveChangesAsync_ShouldSetLastModifiedDate_WhenEntityIsModified()
        {
            var accommodation = new Accommodations
            {
                Name = "Test Accommodation"
            };

            await _dbContext.Accommodations.AddAsync(accommodation);
            await _dbContext.SaveChangesAsync();

            accommodation.Name = "Updated Accommodation";
            await _dbContext.SaveChangesAsync();

            Assert.NotEqual(DateTime.MinValue, accommodation.LastModifiedDate);
            Assert.Equal(accommodation.LastModifiedDate?.Date, DateTime.Now.Date); 
        }
    }
}

