using Domain.Entities.Orders;

namespace Infrastructure.Data.Repositories
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(EFContext dbContext) : base(dbContext)
        {

        }
    }
}
