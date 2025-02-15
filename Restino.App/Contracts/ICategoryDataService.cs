using Restino.App.Services;
using Restino.App.ViewModels;

namespace Restino.App.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<List<CategoryAccommodationViewModel>> GetAllCategoriesWithAccommodations(bool onlyOneCategoryResult, Guid? categoryId);
        Task<ApiResponse<Guid>> CreateCategory(CategoryViewModel categoryViewModel);
        Task<CategoryDetailsViewModel> GetCategoryById(Guid id);
        Task<ApiResponse<Guid>> DeleteCategory(Guid id);
    }
}
