using AutoMapper;
using Moq;
using Restino.Appilcation.UnitTests.Mock;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Features.Category.Queries.GetCategoriesList;
using Restino.Application.Profiles;
using Shouldly;

namespace Restino.Appilcation.UnitTests.Category.Queries
{
    public class GetCategoryListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public GetCategoryListQueryHandlerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
            
        [Fact]
        public async Task GetCategoriesListTest()
        {
            var handler = new GetCategoryListQueryHandler(_mapper, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetCategoryListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryListVm>>();

            result.Count.ShouldBe(7);
        }
    }
}
