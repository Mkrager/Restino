using Restino.Api.IntegrationTests.Base;
using Restino.Application.Features.Reservation.Commands.CreateReservation;
using Restino.Application.Features.Reservation.Queries.GetReservatioDetails;
using Restino.Application.Features.Reservation.Queries.GetReservationList;
using Restino.Application.Features.Reservation.Queries.GetUserReservations;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Restino.Api.IntegrationTests.Controlles
{
    public class ReservationControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        public ReservationControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAllReservation_ReturnsSuccessAndNonEmptyList()
        {
            var client = _factory.GetAuthenticatedClient();
            var response = await client.GetAsync("/api/Reservation");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<ReservationListVm>>(responseString);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task GetUserReservationList_ReturnsSuccessAndNonEmptyList()
        {
            string userId = "TestFirstUserId";
            var client = _factory.GetAuthenticatedClient();
            var response = await client.GetAsync($"/api/Reservation/GetUserReservations/{userId}");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<GetUserReservationListVm>>(responseString);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(result.Count > 0);
        }


        [Fact]
        public async Task GetReservationById_ReturnsSuccessAndValidObject()
        {
            var client = _factory.GetAuthenticatedClient();

            Guid reservationId = Guid.Parse("c4046135-7ef7-4a85-a125-feeea203d4de");
            var response = await client.GetAsync($"/api/Reservation/{reservationId}");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ReservationDetailsVm>(responseString);

            Assert.NotNull(result);
            Assert.Equal(reservationId, result.ReservationId);
            Assert.NotEmpty(result.AdditionalServices);
        }

        [Fact]
        public async Task CreatReservation_ReturnsSuccessAndValidResponse()
        {
            var client = _factory.GetAuthenticatedClient();

            var createReservationCommand = new CreateReservationCommand
            {
                AccommodationsId = Guid.Parse("47fc830b-751c-4b54-88e3-3281d746f3fd"),
                AdditionalServices = "Test",
                CheckInDate = DateTime.Now.AddDays(100),
                CheckOutDate = DateTime.Now.AddDays(124),
                CustomerNote = "Test",
                GuestsCount = 2
            };

            var content = new StringContent(
                JsonSerializer.Serialize(createReservationCommand),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync("/api/Reservation", content);

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Guid>(responseString);

            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var createdAccommodationResponse = await client.GetAsync($"/api/Reservation/{result}");
            createdAccommodationResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task DeleteReservation_ReturnsNoContent_WhenReservationExists()
        {
            var client = _factory.GetAuthenticatedClient();

            Guid reservationId = Guid.Parse("c4046135-7ef7-4a85-a125-feeea203d4de");

            var response = await client.DeleteAsync($"/api/Reservation/{reservationId}");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

    }
}
