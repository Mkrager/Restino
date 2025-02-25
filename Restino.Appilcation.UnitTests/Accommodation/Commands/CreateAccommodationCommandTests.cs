using AutoMapper;
using Moq;
using Restino.Appilcation.UnitTests.Mock;
using Restino.Application.Contracts.Identity;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Exceptions;
using Restino.Application.Features.Accommodation.Commands.CreateAccommodation;
using Restino.Application.Features.Category.Commands.CreateCategoryCommand;
using Restino.Application.Profiles;
using Shouldly;

namespace Restino.Appilcation.UnitTests.Accommodation.Commands
{
    public class CreateAccommodationCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAccommodationRepository> _mockAccommodationRepository;
        private readonly Mock<IUserService> _mockUserService;

        public CreateAccommodationCommandTests()
        {
            _mockAccommodationRepository = RepositoryMocks.GetAccommodationRepository();
            _mockUserService = RepositoryMocks.GetUserService();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Should_Create_Accommodation_Successfully()
        {
            // Arrange
            var handler = new CreateAccommodationCommandHandler(_mapper, _mockAccommodationRepository.Object, _mockUserService.Object);
            var command = new CreateAccommodationCommand
            {
                Name = "Test",
                Address = "Test",
                Capacity = 42,
                CategoryId = Guid.Parse("cf0976f2-83c1-4708-afea-3e4785db6d66"),
                ShortDescription = "Testtesttesttesttesttesttest",
                LongDescription = "Testtesttesttesttesttesttest",
                ImgUrl = "test",
                Price = 42
            };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            var allAccommodation = await _mockAccommodationRepository.Object.ListAllAccommodations(false);
            allAccommodation.Count.ShouldBe(8);

            var createdAccommodation = allAccommodation.FirstOrDefault(a => a.Name == command.Name && a.Address == command.Address);
            createdAccommodation.ShouldNotBeNull();
            createdAccommodation.Name.ShouldBe(command.Name);
            createdAccommodation.Address.ShouldBe(command.Address);
            createdAccommodation.Capacity.ShouldBe(command.Capacity);
            createdAccommodation.CategoryId.ShouldBe(command.CategoryId);
            createdAccommodation.ShortDescription.ShouldBe(command.ShortDescription);
            createdAccommodation.LongDescription.ShouldBe(command.LongDescription);
            createdAccommodation.ImgUrl.ShouldBe(command.ImgUrl);
            createdAccommodation.Price.ShouldBe(command.Price);
        }

        [Fact]
        public async Task Should_Not_Add_Already_Existing_Accommodation()
        {
            // Arrange
            var handler = new CreateAccommodationCommandHandler(_mapper, _mockAccommodationRepository.Object, _mockUserService.Object);
            var command = new CreateAccommodationCommand
            {
                Name = "Test",
                Address = "Test",
                Capacity = 42,
                CategoryId = Guid.Parse("c119661c-1d5a-42c1-8819-6b0885af4d4a"),
                ShortDescription = "Testtesttesttesttesttesttest",
                LongDescription = "Testtesttesttesttesttesttest",
                ImgUrl = "test",
                Price = 42
            };

            // Act
            await handler.Handle(command, CancellationToken.None);
            var exception = await Assert.ThrowsAsync<ValidationException>(async () =>
                await handler.Handle(command, CancellationToken.None)
            );

            // Assert
            exception.ValidationErrors.ShouldContain("An accommodation with the same name and category already exists");

            var allCategories = await _mockAccommodationRepository.Object.ListAllAccommodations(false);
            allCategories.Count.ShouldBe(8);
        }
    }
}
