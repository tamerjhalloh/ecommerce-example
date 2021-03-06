using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Customer
{
    public class AddCustomerRequest
    {
        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; }

        [Required]
        [StringLength(512)]
        public string Address { get; set; }

        [StringLength(16)]
        public string PostalCode { get; set; } 
    }
}
