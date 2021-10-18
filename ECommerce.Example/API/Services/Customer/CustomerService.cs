using API.DTOs.Customer;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Customers;
using System.Linq;

namespace API.Services.Customer
{
    public class CustomerService : BaseService
    {
        public CustomerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<List<CustomerInfoDTO>> SearchAsync(GetCustomerRequest request)
        {
            var repository = UnitOfWork.AsyncRepository<Domain.Entities.Customers.Customer>();
            var customers = await repository
                .ListAsync(x => x.FirstName.Contains(request.Search) || x.LastName.Contains(request.Search));

            var customerDTOs = customers.Select(_ => new CustomerInfoDTO
            {
                Id = _.Id,
                FirstName = _.FirstName,
                LastName = _.LastName,
                Address = _.Address,
                PostalCode = _.PostalCode
            })
            .ToList();

            return customerDTOs;
        }
    }
}
