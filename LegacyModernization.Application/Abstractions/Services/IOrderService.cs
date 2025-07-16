using LegacyModernization.Core.Domain;

namespace LegacyModernization.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task<Order> Create(IEnumerable<OrderItem> items);
    }
}
