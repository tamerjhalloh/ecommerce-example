using Domain.Base;
using System;

namespace Domain.Entities.Orders
{
    public partial class OrderItem : IAggregateRoot
    {
        public OrderItem(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
