using System;

namespace API.DTOs.Product
{
    public class DeleteProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
