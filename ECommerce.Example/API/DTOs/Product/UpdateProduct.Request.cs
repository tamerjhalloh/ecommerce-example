using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Product
{
    public class UpdateProductRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
