using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Order
{
    public class AddOrderRequest
    {
        [Required]
        public Guid CustomerId { get; set; } 

        [Required]
        public List<AddOrderItemRequest> Items { get; set; }
    }

    public class AddOrderItemRequest
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
