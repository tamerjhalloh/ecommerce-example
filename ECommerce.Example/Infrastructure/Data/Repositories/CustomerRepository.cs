using Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(EFContext dbContext) : base(dbContext)
        {

        }
    }
}
