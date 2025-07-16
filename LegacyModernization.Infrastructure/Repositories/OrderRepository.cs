using LegacyModernization.Application.Abstractions.Repositories;
using LegacyModernization.Core.Domain;
using LegacyModernization.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LegacyModernization.Infrastructure.Repositories
{
    public class OrderRepository(AppDbContext dbContext) : BaseRepository(dbContext), IOrderRepository
    {
        public async Task<Order?> Get(Guid id)
        {
            return await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
