using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Product
{
    public class DeleteProductRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
