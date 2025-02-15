using Restino.Application.Features.Accommodation.Commands.CreateAccommodation;
using Restino.Application.Features.Accommodation.Queries.GetAccommodationDetails;
using Restino.Application.Features.Accommodation.Queries.GetAccommodationList;
using Restino.Application.Features.Accommodation.Queries.SearchAccommodationList;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Restino.Api.IntegrationTests.Controlles
{
    public class AccommodationControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        public AccommodationControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }


        [Fact]
        public async Task GetAllAccommodations_ReturnsSuccessAndNonEmptyList()
        {
            var client = _factory.GetAnonymousClient();
            var response = await client.GetAsync("/api/Accommodation");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<AccommodationListVm>>(responseString);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task GetAccommodationById_ReturnsSuccessAndValidObject()
        {
            var client = _factory.GetAnonymousClient();

            Guid accommodationId = Guid.Parse("1a491f3d-94ac-4df8-a244-0ef6c4a5c5b2");
            var response = await client.GetAsync($"/api/Accommodation/{accommodationId}");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<AccommodationDetailsVm>(responseString);

            Assert.NotNull(result);
            Assert.Equal(accommodationId, result.AccommodationsId);
            Assert.NotEmpty(result.Name);
        }

        [Fact]
        public async Task SearchAccommodation_ReturnsSuccess_WhenMatchFound()
        {
            //System.Diagnostics.Debugger.Launch();

            var client = _factory.GetAnonymousClient();
            string accommodationName = "Winter";

            var response = await client.GetAsync($"/api/Accommodation//SearchAccommodation/{accommodationName}");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<SearchAccommodationListVm>>(responseString);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var accommodation in result)
            {
                Assert.Contains(accommodation.Name, "Winter Chalet");
            }
        }

        [Fact]
        public async Task CreatAccommodation_ReturnsSuccessAndValidResponse()
        {
            var jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJNa3JhZ2VyIiwianRpIjoiZTVjYmY1OGItM2NhNy00OWEwLWI1ZjItZWQ3NTE5N2YyNTQ3IiwiZW1haWwiOiJzbWFnYS5tYXhAZ21haWwuY29tIiwidWlkIjoiNzllYzM3ZGYtMjlhZi00NGIzLWE1MDktOGZmZWJhZjllOGQyIiwiZXhwIjoxNzM3NTczMTgzLCJpc3MiOiJSZXN0aW5vSWRlbnRpdHkiLCJhdWQiOiJSZXN0aW5vSWRlbnRpdHlVc2VyIn0.ylFe8xlqxGWRcNuDtn1J1JoXWByRM6CLABuDs6wC3gM";
            var client = _factory.GetAuthenticatedClient(jwtToken);

            var createAccommodationCommand = new CreateAccommodationCommand
            {
                Name = "TestAccommodation",
                ShortDescription = "TestAccommodationDescription",
                Address = "Test42amigo",
                LongDescription = "TestAccommodationDescription",
                Capacity = 2,
                Price = 42000,
                CategoryId = Guid.Parse("cf0976f2-83c1-4708-afea-3e4785db6d66"), 
                ImgUrl = "testimgurl.com"
            };

            var content = new StringContent(
                JsonSerializer.Serialize(createAccommodationCommand),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync("/api/Accommodation", content);

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Guid>(responseString);

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var createdAccommodationResponse = await client.GetAsync($"/api/Accommodation/{result}");
            createdAccommodationResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateAccommodation_ReturnsSuccessAndValidResponse()
        {

            var jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJNa3JhZ2VyIiwianRpIjoiZTVjYmY1OGItM2NhNy00OWEwLWI1ZjItZWQ3NTE5N2YyNTQ3IiwiZW1haWwiOiJzbWFnYS5tYXhAZ21haWwuY29tIiwidWlkIjoiNzllYzM3ZGYtMjlhZi00NGIzLWE1MDktOGZmZWJhZjllOGQyIiwiZXhwIjoxNzM3NTczMTgzLCJpc3MiOiJSZXN0aW5vSWRlbnRpdHkiLCJhdWQiOiJSZXN0aW5vSWRlbnRpdHlVc2VyIn0.ylFe8xlqxGWRcNuDtn1J1JoXWByRM6CLABuDs6wC3gM";
            var client = _factory.GetAuthenticatedClient(jwtToken);

            var updateAccommodationCommand = new
            {
                AccommodationsId = Guid.Parse("f0aefde0-bc3d-4cfc-b477-00b3ddec847c"),
                Name = "UpdatedAccommodation",
                Description = "UpdatedAccommodationDescription",
                Price = 42000,
                CategoryId = Guid.Parse("cf0976f2-83c1-4708-afea-3e4785db6d66")
            };

            var content = new StringContent(
                JsonSerializer.Serialize(updateAccommodationCommand),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PutAsync("/api/Accommodation", content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<Guid>(responseString);

            Assert.NotNull(result);

            var updatedAccommodationResponse = await client.GetAsync($"/api/Accommodation/{updateAccommodationCommand.AccommodationsId}");
            updatedAccommodationResponse.EnsureSuccessStatusCode();
            var updatedAccommodation = JsonSerializer.Deserialize<AccommodationDetailsVm>(await updatedAccommodationResponse.Content.ReadAsStringAsync());
            Assert.Equal("UpdatedAccommodation", updatedAccommodation.Name);
        }




        [Fact]
        public async Task DeleteAccommodation_ReturnsNoContent_WhenCategoryExists()
        {

            var jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJNa3JhZ2VyIiwianRpIjoiZTVjYmY1OGItM2NhNy00OWEwLWI1ZjItZWQ3NTE5N2YyNTQ3IiwiZW1haWwiOiJzbWFnYS5tYXhAZ21haWwuY29tIiwidWlkIjoiNzllYzM3ZGYtMjlhZi00NGIzLWE1MDktOGZmZWJhZjllOGQyIiwiZXhwIjoxNzM3NTczMTgzLCJpc3MiOiJSZXN0aW5vSWRlbnRpdHkiLCJhdWQiOiJSZXN0aW5vSWRlbnRpdHlVc2VyIn0.ylFe8xlqxGWRcNuDtn1J1JoXWByRM6CLABuDs6wC3gM";
            var client = _factory.GetAuthenticatedClient(jwtToken);

            Guid accommdoationId = Guid.Parse("47fc830b-751c-4b54-88e3-3281d746f3fd");

            var response = await client.DeleteAsync($"/api/Accommodation/{accommdoationId}");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
