using Microsoft.AspNetCore.Mvc;
using Restino.App.Contracts;
using Restino.App.Services;
using Restino.App.ViewModels;

namespace Restino.App.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationDataService _reservationDataService;
        private readonly IAccommodationDataService _accommodationDataService;
        public ReservationController(IReservationDataService reservationDataService, IAccommodationDataService accommodationDataService)
        {
            _reservationDataService = reservationDataService;
            _accommodationDataService = accommodationDataService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var reservation = await _reservationDataService.GetAllReservation();
            return View(reservation);
        }
         
        [HttpGet]
        public async Task<IActionResult> Create(Guid id)
        {
            var accommodation = await _accommodationDataService.GetAccommodationById(id);
            var allReservations = await _reservationDataService.GetAllReservation();

            var existingReservations = allReservations
                .Where(r => r.AccommodationsId == id)
                .ToList();

            var reservationModel = new ReservationDetailViewModel
            {
                AccommodationsId = id,
                AccommodationName = accommodation.Name,
                ExistingReservations = existingReservations
            };

            return View(reservationModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationDetailViewModel reservation)
        {
            var newReservation = await _reservationDataService.CreateReservation(reservation);
            TempData["Message"] = HandleResponse<Guid>(newReservation);
            return RedirectToAction(nameof(Create), new { id = reservation.AccommodationsId });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid reservationId)
        {
            var response = await _reservationDataService.DeleteReservation(reservationId);
            return Json(new { success = true });
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
