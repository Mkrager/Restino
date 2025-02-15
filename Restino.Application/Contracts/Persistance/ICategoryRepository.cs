using Restino.Domain.Entities;

namespace Restino.Application.Contracts.Persistance
{
    public interface ICategoryRepository : IAsyncRepository<Categories>
    {
        Task<List<Categories>> GetCategoryWithAccommodation(bool onlyOneCategoryResult, Guid? CategoryId);
        Task<bool> IsCategoryNameUnique(string name);
    }
}
