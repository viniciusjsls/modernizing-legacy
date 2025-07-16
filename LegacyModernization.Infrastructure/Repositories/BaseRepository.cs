using LegacyModernization.Application.Abstractions.Repositories;
using LegacyModernization.Infrastructure.Data;

namespace LegacyModernization.Infrastructure.Repositories
{
    public class BaseRepository(AppDbContext dbContext) : IBaseRepository
    {
        public void Add<T>(T entity) where T : class
        {
            var dbSet = dbContext.Set<T>();

            dbSet.Add(entity);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
