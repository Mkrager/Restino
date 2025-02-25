using Restino.App.Services;
using Restino.App.ViewModels;

namespace Restino.App.Contracts
{
    public interface IAccommodationDataService
    {
        Task<List<AccommodationListViewModel>> GetAllAccommodations(bool? isHotAccommdoation);
        Task<List<AccommodationUserListViewModel>> GetAllUserAccommodations(string userId);
        Task<ApiResponse<List<AccommodationSearchListViewModel>>> SearchAccommodation(string? searchString);
        Task<AccommodationDetailViewModel> GetAccommodationById(Guid id);
        Task<ApiResponse<Guid>> CreateAccommodation(AccommodationDetailViewModel accommodationDetailViewModel);
        Task<ApiResponse<Guid>> UpdateAccommodation(AccommodationDetailViewModel accommodationDetailViewModel);
        Task<ApiResponse<Guid>> DeleteAccommodation(Guid id);
    }
}
