using Restino.Api.IntegrationTests.Base;
using Restino.Application.DTOs;
using System.Net;
using System.Text.Json;

namespace Restino.Api.IntegrationTests.Controlles
{
    [Collection("SequentialTests")]
    public class UserControllerTests : IClassFixture<CustomIdentityWebApplicationFactory<Program>>
    {
        private readonly CustomIdentityWebApplicationFactory<Program> _factory;
        public UserControllerTests(CustomIdentityWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAllUsers_ReturnsSuccessAndNonEmptyList()
        {
            var client = _factory.GetAuthenticatedClient();
            var response = await client.GetAsync("/api/User");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<GetUserDetailsResponse>>(responseString);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task GetUserById_ReturnsSuccessAndValidObject()
        {
            var client = _factory.GetAuthenticatedClient();

            string userId = "0ee44930-75f2-4ffe-bf30-bce82bf45ddd";
            var response = await client.GetAsync($"/api/User/GetById/{userId}");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<GetUserDetailsResponse>(responseString);

            Assert.NotNull(result);
            Assert.Equal(userId, result.UserId);
            Assert.NotEmpty(result.UserName);
        }

        [Fact]
        public async Task SearchUser_ReturnsSuccess_WhenMatchFound()
        {
            var client = _factory.GetAuthenticatedClient();
            string userName = "Admin";

            var response = await client.GetAsync($"/api/User/SearchUser/{userName}");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<SearchUserResponse>>(responseString);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var accommodation in result)
            {
                Assert.Contains(accommodation.UserName, "admin@gmail.com");
            }
        }

        [Fact]
        public async Task DeleteUser_ReturnsNoContent_WhenUserExists()
        {
            var client = _factory.GetAuthenticatedClient();

            Guid userId = Guid.Parse("9d1f8b6d-3c22-4b41-a6d8-1f848d4d2e99");

            var response = await client.DeleteAsync($"/api/User/Delete/{userId}");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

    }
}
