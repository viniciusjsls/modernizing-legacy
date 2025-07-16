using LegacyModernization.Application.Abstractions.Repositories;
using LegacyModernization.Core.Domain;
using MediatR;

namespace LegacyModernization.Application.UseCases.CreateOrder;
public record GetOrderQuery(Guid Id) : IRequest<GetOrderQueryResponse>;
public sealed class GetOrderQueryResponse
{
    public decimal TotalAmount { get; private set; }
    public int NumberOfItems { get; private set; }
    public IEnumerable<OrderItem> Items { get; private set; }

    public GetOrderQueryResponse(Order order)
    {
        TotalAmount = order.Items.Sum(x => x.Price);
        NumberOfItems = order.Items.Count;
        Items = order.Items;
    }
}
public class GetOrderQueryHandler(IOrderRepository orderRepository) : IRequestHandler<GetOrderQuery, GetOrderQueryResponse>
{
    /// <summary>
    /// Handle is responsible to get the order information and transform it
    /// </summary>
    public async Task<GetOrderQueryResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.Get(request.Id);

        if (order == null)
            throw new KeyNotFoundException();

        // it could have additional logic here, for example a notification service
        // or publishing the order to a topic to notify other microservices
        // await additionalService.Publish(order);

        return new GetOrderQueryResponse(order);
    }
}
