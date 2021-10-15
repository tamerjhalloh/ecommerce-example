using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Customers
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {

    }
}
