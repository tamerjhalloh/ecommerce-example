using Domain.Base;

namespace Domain.Entities.Products
{
    public partial class Product : IAggregateRoot
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
