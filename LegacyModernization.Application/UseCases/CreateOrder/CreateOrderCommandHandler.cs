using LegacyModernization.Application.Abstractions.Services;
using LegacyModernization.Core.Domain;
using MediatR;

namespace LegacyModernization.Application.UseCases.CreateOrder;
public record CreateOrderCommand(IEnumerable<OrderItem> Items) : IRequest;
public class CreateOrderCommandHandler(IOrderService orderService) : IRequestHandler<CreateOrderCommand>
{
    /// <summary>
    /// Handle is responsible to orchestrate the order creation logic
    /// </summary>
    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // we could also wrap this method in a transaction to prevent issues
        // for example when SaveChanges is called and we get an error from the publish method

        var order = await orderService.Create(request.Items);

        // it could have additional logic here, for example a notification service
        // or publishing the order to a topic to notify other microservices
        // await additionalService.Publish(order);
    }
}
