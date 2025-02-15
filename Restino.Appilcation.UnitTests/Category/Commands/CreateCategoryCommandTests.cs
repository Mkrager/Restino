using AutoMapper;
using Moq;
using Restino.Appilcation.UnitTests.Mock;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Features.Category.Commands.CreateCategoryCommand;
using Restino.Application.Profiles;
using Shouldly;

namespace Restino.Appilcation.UnitTests.Category.Commands
{
    public class CreateCategoryCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public CreateCategoryCommandTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

            var result = await handler.Handle(new CreateCategoryCommand() { CategoryName = "Test" }, CancellationToken.None);

            var category = result.Category;
            
            category.CategoryName.ShouldBe("Test");

            var allCategories = await _mockCategoryRepository.Object.ListAllAsync();
            allCategories.Count.ShouldBe(8);
        }

        [Fact]
        public async Task Handle_DuplicateCategoryName_ShouldNotBeAddedToCategoriesRepo()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

            await handler.Handle(new CreateCategoryCommand() { CategoryName = "Test" }, CancellationToken.None);
            await handler.Handle(new CreateCategoryCommand() { CategoryName = "Test" }, CancellationToken.None);

            var allCategories = await _mockCategoryRepository.Object.ListAllAsync();
            allCategories.Count.ShouldBe(8);
        }

    }
}
