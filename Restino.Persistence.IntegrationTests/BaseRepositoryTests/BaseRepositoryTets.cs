using Microsoft.EntityFrameworkCore;
using Restino.Domain.Entities;
using Restino.Persistence.Repositories;

namespace Restino.Persistence.IntegrationTests.BaseRepositoryTests
{
    public class BaseRepositoryTets
    {
        private readonly RestinoDbContext _dbContext;
        private readonly BaseRepositrory<Accommodations> _repository;

        public BaseRepositoryTets()
        {
            var options = new DbContextOptionsBuilder<RestinoDbContext>()
                .UseInMemoryDatabase(databaseName: "RestinoDb")
                .Options;
            _dbContext = new RestinoDbContext(options);
            _repository = new BaseRepositrory<Accommodations>(_dbContext);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntityToDatabase()
        {
            var accommodation = new Accommodations { Name = "New Accommodation", CreatedDate = DateTime.UtcNow };

            var result = await _repository.AddAsync(accommodation);

            var addedAccommodation = await _dbContext.Accommodations.FindAsync(result.AccommodationsId);
            Assert.NotNull(addedAccommodation);
            Assert.Equal("New Accommodation", addedAccommodation.Name);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateEntity()
        {
            var accommodation = new Accommodations { Name = "Old Name", CreatedDate = DateTime.UtcNow };
            await _repository.AddAsync(accommodation);

            accommodation.Name = "Updated Name";
            await _repository.UpdateAsync(accommodation);

            var updatedAccommodation = await _dbContext.Accommodations.FindAsync(accommodation.AccommodationsId);
            Assert.NotNull(updatedAccommodation);
            Assert.Equal("Updated Name", updatedAccommodation.Name);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteEntity()
        {
            var accommodation = new Accommodations { Name = "Accommodation to Delete", CreatedDate = DateTime.UtcNow };
            await _repository.AddAsync(accommodation);

            await _repository.DeleteAsync(accommodation);

            var deletedAccommodation = await _dbContext.Accommodations.FindAsync(accommodation.AccommodationsId);
            Assert.Null(deletedAccommodation);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnEntity_WhenEntityExists()
        {
            var accommodation = new Accommodations { Name = "Accommodation", CreatedDate = DateTime.UtcNow };
            await _repository.AddAsync(accommodation);

            var result = await _repository.GetByIdAsync(accommodation.AccommodationsId);

            Assert.NotNull(result);
            Assert.Equal(accommodation.Name, result.Name);
        }

        [Fact]
        public async Task ListAllAsync_ShouldReturnAllEntities()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            var result = await _repository.ListAllAsync();

            Assert.NotNull(result);
            Assert.Equal(28, result.Count);
        }

        [Fact]
        public async Task CheckUserPermissionAsync_ShouldReturnTrue()
        {
            var accommodationId = Guid.NewGuid();
            string userId = "782345634734578";
            string userRole = "Admin";
            var accommodation = new Accommodations
            {
                AccommodationsId = accommodationId,
                UserId = userId,
            };
            await _repository.AddAsync(accommodation);

            var result = await _repository.CheckUserPermissionAsync(userId, accommodationId, userRole);

            Assert.True(result);
        }
    }
}
