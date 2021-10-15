using Domain.Base;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Orders
{
    public partial class Order : BaseEntity<Guid>
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderTime { get; set; }
        public double TotalAmount { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
