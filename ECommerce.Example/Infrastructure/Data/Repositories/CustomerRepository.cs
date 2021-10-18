using Domain.Entities.Customers;

namespace Infrastructure.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(EFContext dbContext) : base(dbContext)
        {

        }
    }
}
