﻿namespace LegacyModernization.Core.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
