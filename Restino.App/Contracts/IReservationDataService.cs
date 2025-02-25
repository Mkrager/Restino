using Restino.App.Services;
using Restino.App.ViewModels;

namespace Restino.App.Contracts
{
    public interface IReservationDataService
    {
        Task<ApiResponse<Guid>> CreateReservation(ReservationDetailViewModel reservationDetailViewModel);
        Task<List<ReservationListViewModel>> GetAllReservation();
        Task<List<ReservationListViewModel>> GetUserReservation(string userId);
        Task<ReservationDetailViewModel> GetReservationById(Guid id);
        Task<ApiResponse<Guid>> DeleteReservation(Guid id);
    }
}
