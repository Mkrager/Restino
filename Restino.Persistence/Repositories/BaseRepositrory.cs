using Microsoft.EntityFrameworkCore;
using Restino.Application.Contracts.Persistance;

namespace Restino.Persistence.Repositories
{
    public class BaseRepositrory<T> : IAsyncRepository<T> where T : class
    {
        protected readonly RestinoDbContext _dbContext;
        public BaseRepositrory(RestinoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            T? t = await _dbContext.Set<T>().FindAsync(id);
            return t;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckUserPermissionAsync(string userId, Guid entityId, string userRole)
        {
            var entity = await _dbContext.Set<T>().FindAsync(entityId);

            var property = typeof(T).GetProperty("UserId");

            var ownerId = property.GetValue(entity)?.ToString();

            if (ownerId == userId || userRole == "Admin")
                return true;

            return false;
        }
    }
}
