using System.ComponentModel.DataAnnotations;

namespace Restino.App.ViewModels
{
    public class ReservationDetailViewModel
    {
        public Guid ReservationId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public Guid AccommodationsId { get; set; }
        public string AccommodationName { get; set; } = string.Empty;
        public int ReservationPrice { get; set; }
        public DateTime ReservationCreated { get; set; }

        [Required(ErrorMessage = "Check-In-Date is required.")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Check-Ou-tDate is required.")]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "GuestsCount is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity should be a positive value")]
        public int GuestsCount { get; set; }

        [Required(ErrorMessage = "AdditionalServices is required.")]
        public string AdditionalServices { get; set; } = string.Empty;

        [Required(ErrorMessage = "CustomerNote is required.")]
        public string CustomerNote { get; set; } = string.Empty;
        public List<ReservationListViewModel> ExistingReservations { get; set; } = default!;
    }
}
