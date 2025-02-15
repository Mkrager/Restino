using Microsoft.EntityFrameworkCore;
using Restino.Application.Contracts.Persistance;
using Restino.Domain.Entities;

namespace Restino.Persistence.Repositories
{
    public class CategoryRepository : BaseRepositrory<Categories>, ICategoryRepository
    {
        public CategoryRepository(RestinoDbContext dbcontext) : base(dbcontext)
        {
            
        }

        public async Task<List<Categories>> GetCategoryWithAccommodation(bool onlyOneCategoryResult, Guid? categoryId)
        {
            var allCategories = await _dbContext.Categories.Include(
                x => x.Accommodations).ToListAsync();
            if (onlyOneCategoryResult)
            {
                allCategories = allCategories.Where(x => x.Accommodations.Any(a => a.CategoryId == categoryId)).ToList();
            }

            return allCategories;
        }

        public Task<bool> IsCategoryNameUnique(string name)
        {
            var matches = _dbContext.Categories.Any(n => n.CategoryName.Equals(name));
            return Task.FromResult(matches);
        }
    }
}
