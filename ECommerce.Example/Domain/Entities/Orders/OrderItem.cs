using Domain.Base;
using Domain.Entities.Products;
using System;

namespace Domain.Entities.Orders
{
    public partial class OrderItem : BaseEntity<Guid>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
