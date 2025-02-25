using Restino.App.Contracts;
using Restino.App.ViewModels;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Restino.App.Services
{
    public class ReservationDataService : IReservationDataService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthenticationService _authenticationService;
        public ReservationDataService(HttpClient httpClient, IAuthenticationService authenticationService)
        {
            _httpClient = httpClient;
            _authenticationService = authenticationService;
        }

        public async Task<ApiResponse<Guid>> CreateReservation(ReservationDetailViewModel reservationDetailViewModel)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7288/api/Reservation")
                {
                    Content = new StringContent(JsonSerializer.Serialize(reservationDetailViewModel), Encoding.UTF8, "application/json")
                };

                string accessToken = _authenticationService.GetAccessToken();

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    var reservationDetails = JsonSerializer.Deserialize<Guid>(responseContent);

                    return new ApiResponse<Guid>(System.Net.HttpStatusCode.OK, reservationDetails);
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                var errorMessages = JsonSerializer.Deserialize<List<string>>(errorContent);
                return new ApiResponse<Guid>(System.Net.HttpStatusCode.BadRequest, Guid.Empty, errorMessages.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return new ApiResponse<Guid>(System.Net.HttpStatusCode.BadRequest, Guid.Empty, ex.Message);
            }
        }

        public async Task<List<ReservationListViewModel>> GetAllReservation()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7288/api/Reservation");

            string accessToken = _authenticationService.GetAccessToken();

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var reservations = JsonSerializer.Deserialize<List<ReservationListViewModel>>(responseContent);

                return reservations;    
            }

            return new List<ReservationListViewModel>();
        }

        public async Task<ReservationDetailViewModel> GetReservationById(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7288/api/Reservation/{id}");

            string accessToken = _authenticationService.GetAccessToken();

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var reservationDetails = JsonSerializer.Deserialize<ReservationDetailViewModel>(responseContent);

                return reservationDetails;
            }

            return new ReservationDetailViewModel();
        }

        public async Task<ApiResponse<Guid>> DeleteReservation(Guid id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7288/api/reservation/{id}");

                string accessToken = _authenticationService.GetAccessToken();

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return new ApiResponse<Guid>(System.Net.HttpStatusCode.NoContent, Guid.Empty);
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                var errorMessages = JsonSerializer.Deserialize<List<string>>(errorContent);
                return new ApiResponse<Guid>(System.Net.HttpStatusCode.BadRequest, Guid.Empty, errorMessages.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return new ApiResponse<Guid>(System.Net.HttpStatusCode.BadRequest, Guid.Empty, ex.Message);
            }
        }

        public async Task<List<ReservationListViewModel>> GetUserReservation(string userId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7288/api/Reservation/GetUserReservations/{userId}");

            string accessToken = _authenticationService.GetAccessToken();

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var reservations = JsonSerializer.Deserialize<List<ReservationListViewModel>>(responseContent);

                return reservations;    
            }

            return new List<ReservationListViewModel>();
        }
    }
}
