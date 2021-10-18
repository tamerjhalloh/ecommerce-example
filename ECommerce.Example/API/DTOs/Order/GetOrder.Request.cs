using API.DTOs.Base;
using System;

namespace API.DTOs.Order
{
    public class GetOrderRequest : PagingDTO
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderTimeFrom { get; set; }
        public DateTime OrderTimeTo { get; set; }  
    }
}
