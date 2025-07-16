using LegacyModernization.Application.Abstractions.Repositories;
using LegacyModernization.Core.Domain;
using LegacyModernization.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LegacyModernization.Infrastructure.Repositories
{
    public class OrderRepository(AppDbContext dbContext) : BaseRepository(dbContext), IOrderRepository
    {
        // we could also have a readonly repository to enforce AsNoTracking() and gain performance
        // it would also reduce code smells in repository layer
        public async Task<Order?> Get(Guid id)
        {
            return await dbContext.Orders.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
