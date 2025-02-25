using Restino.Domain.Entities;

namespace Restino.Application.Contracts.Persistance
{
    public interface IAccommodationRepository : IAsyncRepository<Accommodations>
    {
        Task<bool> IsAccommodationNameAndCategoryUnique(string name, Guid categoryId);
        Task<bool> IsAccommodationNameAndCategoryUniqueUpdate(string name, Guid categoryId, Guid? accommodationsId);
        Task<List<Accommodations>> SearchAccommodation(string searchString);
        Task<List<Accommodations>> ListAllAccommodations(bool isAccommodationHot);
        Task<List<Accommodations>> ListUserAccommodations(string userId);
    }
}
