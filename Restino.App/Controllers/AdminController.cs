using Microsoft.AspNetCore.Mvc;
using Restino.App.Contracts;

namespace Restino.App.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICategoryDataService _categoryDataService;
        public AdminController(ICategoryDataService categoryDataService)
        {
            _categoryDataService = categoryDataService;
        }

        [HttpGet]
        public async Task<IActionResult> Panel()
        {
            var allCategories = await _categoryDataService.GetAllCategories();
            return View(allCategories);
        }
    }
}
