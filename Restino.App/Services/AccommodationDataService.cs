using AutoMapper;
using Restino.App.Contracts;
using Restino.App.ViewModels;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Restino.App.Services
{
    public class AccommodationDataService : IAccommodationDataService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly HttpClient _httpClient;

        public AccommodationDataService(HttpClient httpClient, IAuthenticationService authenticationService)
        {
            _httpClient = httpClient;
            _authenticationService = authenticationService;
        }

        public async Task<ApiResponse<Guid>> CreateAccommodation(AccommodationDetailViewModel accommodationDetailViewModel)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7288/api/Accommodation")
                {
                    Content = new StringContent(JsonSerializer.Serialize(accommodationDetailViewModel), Encoding.UTF8, "application/json")
                };

                string accessToken = _authenticationService.GetAccessToken();

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    var accommodationDetails = JsonSerializer.Deserialize<Guid>(responseContent);

                    return new ApiResponse<Guid>(System.Net.HttpStatusCode.OK, accommodationDetails);
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

        public async Task<ApiResponse<Guid>> DeleteAccommodation(Guid id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7288/api/Accommodation/{id}");

                string accessToken = _authenticationService.GetAccessToken();

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    var accommodationDetails = JsonSerializer.Deserialize<AccommodationDetailViewModel>(responseContent);

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

        public async Task<AccommodationDetailViewModel> GetAccommodationById(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7288/api/Accommodation/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var accommodationDetails = JsonSerializer.Deserialize<AccommodationDetailViewModel>(responseContent);

                return accommodationDetails;
            }

            return new AccommodationDetailViewModel();
        }

        public async Task<List<AccommodationListViewModel>> GetAllAccommodations(bool? isAccommodationHot)
        {
            var queryString = isAccommodationHot.HasValue ? $"?isAccommodationHot={isAccommodationHot.Value}" : "";
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7288/api/Accommodation{queryString}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var accommodations = JsonSerializer.Deserialize<List<AccommodationListViewModel>>(responseContent);

                return accommodations;
            }

            return new List<AccommodationListViewModel>();
        }

        public async Task<List<AccommodationUserListViewModel>> GetAllUserAccommodations(string userId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7288/api/Accommodation/GetUserAccommodations/{userId}");

            string accessToken = _authenticationService.GetAccessToken();

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<AccommodationUserListViewModel>>(responseContent);
            }

            return new List<AccommodationUserListViewModel>();
        }

        public async Task<ApiResponse<List<AccommodationSearchListViewModel>>> SearchAccommodation(string? AccommodationName)
        {
            try
            {
                var url = string.IsNullOrWhiteSpace(AccommodationName)
                    ? "https://localhost:7288/api/Accommodation/SearchAccommodation"
                    : $"https://localhost:7288/api/Accommodation/SearchAccommodation/{Uri.EscapeDataString(AccommodationName)}";

                var request = new HttpRequestMessage(HttpMethod.Get, url);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    var accommodationDetails = JsonSerializer.Deserialize<List<AccommodationSearchListViewModel>>(responseContent);

                    return new ApiResponse<List<AccommodationSearchListViewModel>>(System.Net.HttpStatusCode.OK, accommodationDetails);
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                var errorMessages = JsonSerializer.Deserialize<List<string>>(errorContent);
                return new ApiResponse<List<AccommodationSearchListViewModel>>(System.Net.HttpStatusCode.BadRequest, new List<AccommodationSearchListViewModel>(), errorMessages.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<AccommodationSearchListViewModel>>(System.Net.HttpStatusCode.BadRequest, new List<AccommodationSearchListViewModel>(), ex.Message);
            }
        }



        public async Task<ApiResponse<Guid>> UpdateAccommodation(AccommodationDetailViewModel accommodationDetailViewModel)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7288/api/Accommodation")
                {
                    Content = new StringContent(JsonSerializer.Serialize(accommodationDetailViewModel), Encoding.UTF8, "application/json")
                };

                string accessToken = _authenticationService.GetAccessToken();

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    var accommodationDetails = JsonSerializer.Deserialize<AccommodationDetailViewModel>(responseContent);

                    return new ApiResponse<Guid>(System.Net.HttpStatusCode.OK, accommodationDetails.AccommodationsId);
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
    }
}
