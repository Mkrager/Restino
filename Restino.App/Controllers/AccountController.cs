using Microsoft.AspNetCore.Mvc;
using Restino.App.Contracts;
using Restino.App.Services;

namespace Restino.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserDataService _userDataService;
        private readonly IAccommodationDataService _accommodationDataService;
        private readonly IReservationDataService _reservationDataService;
        public AccountController(IAuthenticationService authenticationService, IAccommodationDataService accommodationDataService, IUserDataService userDataService, IReservationDataService reservationDataService)
        {
            _authenticationService = authenticationService;
            _accommodationDataService = accommodationDataService;
            _userDataService = userDataService;
            _reservationDataService = reservationDataService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string firstName, string lastName, string userName, string email, string password)
        {
            var register = await _authenticationService.Register(firstName, lastName, userName, email, password);
            TempData["Message"] = HandleResponse<bool>(register);
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var login = await _authenticationService.Authenticate(email, password);
            TempData["Message"] = HandleResponse<bool>(login);

            if (login.Data)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Overview(string accountId)
        {
            var account = await _userDataService.GetUserDetails(accountId);
            var accommodations = await _accommodationDataService.GetAllUserAccommodations(accountId);
            var reservations = await _reservationDataService.GetUserReservation(accountId);
            TempData["Accommodations"] = accommodations;
            TempData["Reservations"] = reservations;
            return View(account);
        }

        public async Task<IActionResult> Logout()
        {
            await _authenticationService.Logout();
            return Redirect("/Home");
        }

        private string HandleResponse<T>(ApiResponse<T> response, string successMessage = "")
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
