using Microsoft.EntityFrameworkCore;
using Restino.Application.Contracts.Persistance;
using Restino.Domain.Entities;

namespace Restino.Persistence.Repositories
{
    public class ReservationRepository : BaseRepositrory<Reservations>, IReservationRepository
    {
        public ReservationRepository(RestinoDbContext dbContext) : base(dbContext)
        {

        }

        public Task<List<Reservations>> ListUserReservations(string userId)
        {
            var userReservation = _dbContext.Reservation.Where(e => e.UserId == userId);
            return userReservation.ToListAsync();
        }

        public async Task<bool> IsDateRangeValid(DateTime checkInDate, DateTime checkOutDate, Guid accommodationId)
        {

            if (checkInDate >= checkOutDate)
            {
                return true;
            }

            var currentDate = DateTime.Today;
            if (checkInDate < currentDate)
            {
                return true;
            }

            var lastDate = currentDate.AddYears(1);
            if (checkInDate > lastDate)
            {
                return true;
            }

            var isOverlap = await _dbContext.Reservation
                .Where(r => r.AccommodationsId == accommodationId)
                .AnyAsync(r =>
                    (checkInDate < r.CheckOutDate && checkOutDate > r.CheckInDate) 
                );

            return isOverlap;
        }


        public Task<bool> IsGuestsCountWithinCapacity(int guestsCount, Guid accommodationId)
        {
            var exceedsCapacity = _dbContext.Accommodations
                .Where(e => e.AccommodationsId == accommodationId)
                .Any(e => guestsCount > e.Capacity);

            return Task.FromResult(exceedsCapacity);
        }

        public Task<double> TotalPrice(Guid accommodationId, DateTime checkInDate, DateTime checkOutDate)
        {
            var accommodation = _dbContext.Accommodations
                .FirstOrDefaultAsync(a => a.AccommodationsId == accommodationId);

            var numberOfDays = (checkOutDate - checkInDate).TotalDays;

            var totalPrice = numberOfDays * accommodation.Result.Price;

            return Task.FromResult(totalPrice);
        }
    }
}
