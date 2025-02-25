using Restino.App.Contracts;
using Restino.App.ViewModels;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Restino.App.Services
{
    public class CategoriesDataService : ICategoryDataService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthenticationService _authenticationService;

        public CategoriesDataService(HttpClient httpClient, IAuthenticationService authenticationService)
        {
            _httpClient = httpClient;
            _authenticationService = authenticationService;
        }

        public async Task<ApiResponse<Guid>> CreateCategory(CategoryViewModel categoryViewModel)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7288/api/Category")
                {
                    Content = new StringContent(JsonSerializer.Serialize(categoryViewModel), Encoding.UTF8, "application/json")
                };

                string accessToken = _authenticationService.GetAccessToken();

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    var categoryId = JsonSerializer.Deserialize<Guid>(responseContent);

                    return new ApiResponse<Guid>(System.Net.HttpStatusCode.OK, categoryId);
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

        public async Task<ApiResponse<Guid>> DeleteCategory(Guid id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7288/api/Category/{id}");

                string accessToken = _authenticationService.GetAccessToken();

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    var categoriesDetails = JsonSerializer.Deserialize<CategoryDetailsViewModel>(responseContent);

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

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7288/api/Category/all");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var categories = JsonSerializer.Deserialize<List<CategoryViewModel>>(responseContent);

                return categories;
            }
            return new List<CategoryViewModel>();
        }

        public async Task<List<CategoryAccommodationViewModel>> GetAllCategoriesWithAccommodations(bool onlyOneCategoryResult, Guid? categoryId)
        {
            var queryParams = new List<string>();

            queryParams.Add($"onlyOneCategoryResult={onlyOneCategoryResult.ToString().ToLower()}");

            if (categoryId.HasValue)
            {
                queryParams.Add($"categoryId={categoryId.Value}");
            }

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7288/api/Category/allwithcategories{queryString}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var categoriesWithAccommodations = JsonSerializer.Deserialize<List<CategoryAccommodationViewModel>>(responseContent);

                return categoriesWithAccommodations;
            }

            return new List<CategoryAccommodationViewModel>();
        }


        public async Task<CategoryDetailsViewModel> GetCategoryById(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7288/api/Category/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var categoryDetails = JsonSerializer.Deserialize<CategoryDetailsViewModel>(responseContent);

                return categoryDetails;
            }

            return new CategoryDetailsViewModel();
        }
    }
}
