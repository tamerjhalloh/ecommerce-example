using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Product
{
    public class AddProductRequest
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
