using Domain.Base;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Orders
{
    public partial class Order : BaseEntity<Guid>
    {
        public Guid CustomerId { get; internal set; }
        public DateTime OrderTime { get; internal set; }
        public double TotalAmount { get; internal set; }

        public virtual ICollection<OrderItem> Items { get; internal set; }
    }
}
