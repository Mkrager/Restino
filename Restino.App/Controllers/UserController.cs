using Microsoft.AspNetCore.Mvc;
using Restino.App.Contracts;

namespace Restino.App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserDataService _userDataService;
        private readonly IAccommodationDataService _accommodationDataService;
        private readonly IReservationDataService _reservationDataService;

        public UserController(IUserDataService userDataService, IAccommodationDataService accommodationDataService, IReservationDataService reservationDataService)
        {
            _userDataService = userDataService;
            _accommodationDataService = accommodationDataService;
            _reservationDataService = reservationDataService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
            var searchResult = await _userDataService.SearchUser(searchString);
            return View(searchResult);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string userId)
        {
            var result = await _userDataService.GetUserDetails(userId);
            var accommodations = await _accommodationDataService.GetAllUserAccommodations(userId);
            var reservations = await _reservationDataService.GetUserReservation(userId);
            TempData["Accommodations"] = accommodations;
            TempData["Reservations"] = reservations;
            return View(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string userId)
        {
            var response = await _userDataService.DeleteUser(userId);
            return Json(new { success = true });
        }

    }
}
