using AutoMapper;
using Moq;
using Restino.Appilcation.UnitTests.Mock;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Features.Accommodation.Commands.CreateAccommodation;
using Restino.Application.Features.Accommodation.Commands.UpdateAccommodation;
using Restino.Application.Profiles;
using Restino.Domain.Entities;
using Shouldly;

namespace Restino.Appilcation.UnitTests.Accommodation.Commands
{
    public class UpdateAccommodationCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAccommodationRepository> _mockAccommodationRepository;

        public UpdateAccommodationCommandTests()
        {
            _mockAccommodationRepository = RepositoryMocks.GetAccommodationRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task UpdateAccommodation_ValidCommand_UpdatesAccommodationSuccessfully()
        {
            // Arrange
            var handler = new UpdateAccommodationCommandHandler(_mapper, _mockAccommodationRepository.Object);
            var updateCommand = new UpdateAccommodationCommand
            {
                AccommodationsId = Guid.Parse("1a4ab6df-66b8-46f7-8198-c94332964001"),
                Name = "Updated Test",
                Address = "Updated Address",
                Capacity = 50,
                CategoryId = Guid.Parse("c119661c-1d5a-42c1-8819-6b0885af4d4a"),
                ShortDescription = "Updated Description",
                ImgUrl = "updated_image_url",
                Price = 4200,
                UserRole = "Admin"
            };

            // Act
            await handler.Handle(updateCommand, CancellationToken.None);

            // Assert
            var updatedAccommodation = await _mockAccommodationRepository.Object.GetByIdAsync(updateCommand.AccommodationsId);

            updatedAccommodation.ShouldNotBeNull();
            updatedAccommodation.Name.ShouldBe(updateCommand.Name);
            updatedAccommodation.Address.ShouldBe(updateCommand.Address);
            updatedAccommodation.Capacity.ShouldBe(updateCommand.Capacity);
            updatedAccommodation.CategoryId.ShouldBe(updateCommand.CategoryId);
            updatedAccommodation.ShortDescription.ShouldBe(updateCommand.ShortDescription);
            updatedAccommodation.ImgUrl.ShouldBe(updateCommand.ImgUrl);
            updatedAccommodation.Price.ShouldBe(updateCommand.Price);
        }
    }
}
