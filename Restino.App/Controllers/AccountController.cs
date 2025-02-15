using Microsoft.AspNetCore.Mvc;
using Restino.App.Contracts;
using Restino.App.Services;

namespace Restino.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccommodationDataService _accommodationDataService;
        public AccountController(IAuthenticationService authenticationService, IAccommodationDataService accommodationDataService)
        {
            _authenticationService = authenticationService;
            _accommodationDataService = accommodationDataService;
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
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Overview(string accountId)
        {
            var account = await _authenticationService.GetAccountDetails(accountId);
            var accommodations = await _accommodationDataService.GetAllUserAccommodations(accountId);
            TempData["Accommodations"] = accommodations;
            return View(account);
        }

        public async Task<IActionResult> Logout()
        {
            await _authenticationService.Logout();
            return Redirect("/Home");
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
