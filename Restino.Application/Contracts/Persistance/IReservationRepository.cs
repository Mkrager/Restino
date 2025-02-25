using Restino.Domain.Entities;

namespace Restino.Application.Contracts.Persistance
{
    public interface IReservationRepository : IAsyncRepository<Reservations>
    {
        Task<bool> IsGuestsCountWithinCapacity(int guestsCount, Guid accommodationId);
        Task<bool> IsDateRangeValid(DateTime checkInDate, DateTime checkOutDate, Guid accommodationId);
        Task<double> TotalPrice(Guid accommodationId, DateTime checkInDate, DateTime checkOutDate);
        Task<List<Reservations>> ListUserReservations(string userId);
    }
}
