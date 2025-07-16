using LegacyModernization.Application.Abstractions.Repositories;
using LegacyModernization.Application.Abstractions.Services;
using LegacyModernization.Core.Domain;

namespace LegacyModernization.Application.Services
{
    public class OrderService(IOrderRepository repository) : IOrderService
    {
        public async Task Create(IEnumerable<OrderItem> items)
        {
            var order = new Order();
            var domainValidation = order.AddItems(items);

            if (domainValidation.Any())
            {
                // could be a custom exception to handle domain validation payload
                throw new Exception();
            }

            repository.Add(order);

            await repository.SaveChangesAsync();
        }
    }
}
