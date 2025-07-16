namespace LegacyModernization.Core.Domain
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
