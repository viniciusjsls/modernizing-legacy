namespace LegacyModernization.Core.Domain
{
    public class OrderItem
    {
        public OrderItem() { }

        public OrderItem(Guid orderId, string name, decimal price)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            Name = name;
            Price = price;
        }

        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
