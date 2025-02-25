namespace Restino.Application.Features.Reservation.Queries.GetReservationList
{
    public class ReservationListVm
    {
        public Guid ReservationId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public Guid AccommodationsId { get; set; }
        public double ReservationPrice { get; set; } 
        public DateTime ReservationCreated { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int GuestsCount { get; set; }
        public string AdditionalServices { get; set; } = string.Empty;
        public string CustomerNote { get; set; } = string.Empty;
    }
}
