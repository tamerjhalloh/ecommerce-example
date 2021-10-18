using Domain.Base;
using System;

namespace Domain.Entities.Products
{
    public partial class Product : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public double Price { get; set; }

    }
}
