using System;
using System.Collections.Generic;

namespace Domain.Entities.Orders
{
    public partial class Order : IAggregateRoot
    {
        public Order()
        {
            Items  = new HashSet<OrderItem>();
        }

        public Order(Guid customerId, DateTime orderTime, double totalAmount) : this()
        {
            CustomerId = customerId;
            OrderTime = orderTime;
            TotalAmount = totalAmount; 
        }


        public void UpdateItems(HashSet<OrderItem> items)  
        {
            Items = items;
        }

    }
}
