using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Customer
{
    public class DeleteCustomerRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
