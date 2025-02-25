using AutoMapper;
using Moq;
using Restino.Appilcation.UnitTests.Mock;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Features.Category.Commands.DeleteCategoryCommand;
using Restino.Application.Profiles;
using Shouldly;

namespace Restino.Appilcation.UnitTests.Category.Commands
{
    public class DeleteCategoryCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public DeleteCategoryCommandTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Delete_Category_RemovesCategoryFromRepo()
        {
            var handler = new DeleteCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);
            await handler.Handle(new DeleteCategoryCommand() { CategoriesId = Guid.Parse("c119661c-1d5a-42c1-8819-6b0885af4d4a") }, CancellationToken.None);

            var allCategories = await _mockCategoryRepository.Object.ListAllAsync();
            allCategories.Count.ShouldBe(6);
        }
    }
}
