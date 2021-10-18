using Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Repositories
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(EFContext dbContext) : base(dbContext)
        {

        }
    }
}
