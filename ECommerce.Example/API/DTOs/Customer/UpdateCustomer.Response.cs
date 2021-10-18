using System;

namespace API.DTOs.Customer
{
    public class UpdateCustomerResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
