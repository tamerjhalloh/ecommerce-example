using API.DTOs.Customer;
using API.DTOs.Product;
using System;
using System.Collections.Generic;

namespace API.DTOs.Order
{
    public class OrderInfoDTO
    {
        public Guid Id { get; set; }
        public CustomerInfoDTO Customer { get; set; }
        public DateTime OrderTime { get; set; }
        public double TotalAmount { get; set; }

        public List<OrderItemInfoDTO> Items { get; set; }
    }

    public class OrderItemInfoDTO
    {
        public Guid Id { get; set; }
        public ProductInfoDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}
