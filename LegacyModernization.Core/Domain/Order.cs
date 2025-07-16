using LegacyModernization.Core.Validators;

namespace LegacyModernization.Core.Domain
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Add items to the order
        /// </summary>
        /// <param name="items"></param>
        /// <returns>Domain details with reason for failure</returns>
        public IEnumerable<DomainValidation> AddItems(IEnumerable<OrderItem> items)
        {
            var validations = CanAddItems(items);

            if (validations.Any())
                return validations;
            
            Items = [.. items];
            return [];
        }

        /// <summary>
        /// Check if items data is valid
        /// </summary>
        /// <param name="items"></param>
        /// <returns>Domain details with reason for failure</returns>
        private IEnumerable<DomainValidation> CanAddItems(IEnumerable<OrderItem> items)
        {
            // run domain validation
            return [];
        }

        public Guid Id { get; init; }
        public List<OrderItem> Items { get; private set; }
    }
}
