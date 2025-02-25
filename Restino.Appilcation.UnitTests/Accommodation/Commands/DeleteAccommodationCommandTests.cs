using AutoMapper;
using Moq;
using Restino.Appilcation.UnitTests.Mock;
using Restino.Application.Contracts.Identity;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Features.Accommodation.Commands.DeleteAccommodation;
using Restino.Application.Profiles;
using Shouldly;

namespace Restino.Appilcation.UnitTests.Accommodation.Commands
{
    public class DeleteAccommodationCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAccommodationRepository> _mockAccommodationRepository;

        public DeleteAccommodationCommandTests()
        {
            _mockAccommodationRepository = RepositoryMocks.GetAccommodationRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Delete_Accommodation_RemovesAccommodationFromRepo()
        {
            var handler = new DeleteAccommodationCommandHandler(_mapper, _mockAccommodationRepository.Object);
            await handler.Handle(new DeleteAccommodationCommand() { AccommodationsId = Guid.Parse("2a4ab6df-66b8-46f7-8198-c94332964002"), UserRole = "Admin", UserId = "123345089345" }, CancellationToken.None);

            var allAccommodations = await _mockAccommodationRepository.Object.ListAllAccommodations(false);
            allAccommodations.Count.ShouldBe(6);
        }
    }
}
