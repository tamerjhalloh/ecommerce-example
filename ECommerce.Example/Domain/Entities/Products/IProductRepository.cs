using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Products
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}
