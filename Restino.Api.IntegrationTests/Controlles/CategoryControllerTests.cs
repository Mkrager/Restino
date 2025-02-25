using Restino.Api.IntegrationTests.Base;
using Restino.Application.Features.Category.Queries.GetCategoriesList;
using Restino.Application.Features.Category.Queries.GetCategoriesListWithAccommodation;
using Restino.Application.Features.Category.Queries.GetCategoryDetails;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Restino.Api.IntegrationTests.Controlles
{
    public class CategoryControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        public CategoryControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }


        [Fact]
        public async Task GetAllCategories_ReturnsSuccessAndNonEmptyResult()
        {
            // Arrange
            var client = _factory.GetAnonymousClient();

            // Act
            var response = await client.GetAsync("/api/category/all");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<CategoryListVm>>(responseString);

            Assert.NotNull(result);
            Assert.IsType<List<CategoryListVm>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetAllCategoriesWithAccommodations_ReturnsSuccessAndNonEmptyResult()
        {
            // Arrange
            var client = _factory.GetAnonymousClient();

            // Act
            var response = await client.GetAsync("/api/category/allwithcategories");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<CategoryAccommodationListVm>>(responseString);

            Assert.NotNull(result);
            Assert.IsType<List<CategoryAccommodationListVm>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetCategoryById_ReturnsSuccessAndCorrectData_WhenCategoryExists()
        {
            // Arrange
            var client = _factory.GetAnonymousClient();
            Guid existingCategoryId = Guid.Parse("8f67819c-0d09-43e8-b64f-17c9123b6040");

            // Act
            var response = await client.GetAsync($"/api/category/{existingCategoryId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<CategoryDetailsVm>(responseString);

            Assert.NotNull(result);
            Assert.IsType<CategoryDetailsVm>(result);
            Assert.Equal(existingCategoryId, result.CategoriesId);
        }

        [Fact]
        public async Task CreateCategory_ReturnsSuccessAndValidResponse()
        {
            // Arrange
            var client = _factory.GetAuthenticatedClient();
            
            var createCategoryCommand = new
            {
                CategoryName = "TestCategory",
                Description = "TestCategoryDescription"
            };

            var content = new StringContent(
                JsonSerializer.Serialize(createCategoryCommand),
                Encoding.UTF8,
                "application/json"
            );

            // Act
            var response = await client.PostAsync("/api/category", content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Guid>(responseString);

            Assert.NotNull(result);
            Assert.NotEqual(Guid.Empty, result);
        }

        [Fact]
        public async Task DeleteCategory_ReturnsNoContent_WhenCategoryExists()
        {
            var client = _factory.GetAuthenticatedClient();

            Guid categoryId = Guid.Parse("8f67819c-0d09-43e8-b64f-17c9123b6040");

            var response = await client.DeleteAsync($"/api/Category/{categoryId}");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

    }
}
