using System;

namespace API.DTOs.Customer
{
    public class AddCustomerResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
