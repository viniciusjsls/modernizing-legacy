using LegacyModernization.Core.Domain;

namespace LegacyModernization.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task Create(IEnumerable<OrderItem> items);
    }
}
