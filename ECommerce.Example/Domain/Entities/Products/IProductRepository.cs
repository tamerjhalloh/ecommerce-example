using Domain.Interfaces;

namespace Domain.Entities.Products
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}
