using Microsoft.AspNetCore.Mvc;
using Restino.App.Contracts;
using Restino.App.ViewModels;

namespace Restino.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccommodationDataService _accommodationDataService;
        private readonly ICategoryDataService _categoryDataService;

        public HomeController(IAccommodationDataService accommodationDataService, ICategoryDataService categoryDataService)
        {
            _accommodationDataService = accommodationDataService;
            _categoryDataService = categoryDataService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allAccommodation = await _accommodationDataService.GetAllAccommodations(true);
            var allCategories = await _categoryDataService.GetAllCategories();

            var model = new Tuple<List<AccommodationListViewModel>, List<CategoryViewModel>>(allAccommodation, allCategories);

            var token = Request.Cookies["access_token"];
            bool isAuthenticated = !string.IsNullOrEmpty(token);

            ViewBag.IsAuthenticated = isAuthenticated;

            return View(model);
        }
    }
}
