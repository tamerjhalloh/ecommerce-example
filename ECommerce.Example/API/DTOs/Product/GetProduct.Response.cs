using System;

namespace API.DTOs.Product
{
    public class ProductInfoDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
