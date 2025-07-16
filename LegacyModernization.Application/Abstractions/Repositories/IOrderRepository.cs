using LegacyModernization.Core.Domain;

namespace LegacyModernization.Application.Abstractions.Repositories
{
    public interface IOrderRepository : IBaseRepository
    {
        Task<Order?> Get(Guid id);
    }
}
