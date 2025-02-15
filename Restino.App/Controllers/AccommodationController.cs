using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restino.App.Contracts;
using Restino.App.Services;
using Restino.App.ViewModels;

namespace Restino.App.Controllers
{
    public class AccommodationController : Controller
    {
        private readonly IAccommodationDataService _accommodationDataService;
        private readonly ICategoryDataService _categoryDataService;
        public AccommodationController(IAccommodationDataService accommodationDataService, ICategoryDataService categoryDataService)
        {
            _accommodationDataService = accommodationDataService;
            _categoryDataService = categoryDataService;
        }

        public async Task<SelectList> Categories()
        {
            var categories = await _categoryDataService.GetAllCategories();
            var categoryList = new SelectList(categories, "CategoriesId", "CategoryName");
            return categoryList;
        }

        [HttpGet]
        public async Task<IActionResult> SearchList(string searchString)
        {
            var searchResult = await _accommodationDataService.SearchAccommodation(searchString);
            TempData["SearchMessage"] = HandleResponse<List<AccommodationSearchListViewModel>>(searchResult, $"Result {searchString}");
            return View(searchResult.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid AccommodationId)
        {
            var accommodation = await _accommodationDataService.GetAccommodationById(AccommodationId);
            return View(accommodation);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryDataService.GetAllCategories();
            TempData["Categories"] = await Categories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccommodationDetailViewModel accommodation)
        {
            var newAccommodation = await _accommodationDataService.CreateAccommodation(accommodation);
            var categories = await _categoryDataService.GetAllCategories();
            TempData["Categories"] = await Categories();
            TempData["Message"] = HandleResponse<Guid>(newAccommodation);
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var responce = await _accommodationDataService.DeleteAccommodation(id);
            TempData["Message"] = "Deleted";
            return Json(new { redirectUrl = Url.Action("Index", "Home") });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var accommodation = await _accommodationDataService.GetAccommodationById(id);
            var categories = await _categoryDataService.GetAllCategories();
            TempData["Categories"] = await Categories();
            return View(accommodation);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AccommodationDetailViewModel accommodation)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kv => kv.Key,
                    kv => kv.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return Json(new { errors });
            }

            var updatedAccommodation = await _accommodationDataService.UpdateAccommodation(accommodation);
            TempData["Message"] = HandleResponse<Guid>(updatedAccommodation);
            return Json(new { redirectToUrl = Url.Action("Update", "Accommdoation") });
        }

        private string HandleResponse<T>(ApiResponse<T> response, string successMessage = "Success")
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return successMessage;
            }
            else
            {
                return response.ErrorText;
            }
        }
    }
}
