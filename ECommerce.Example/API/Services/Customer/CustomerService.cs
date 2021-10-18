using API.DTOs.Customer;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            request.Search ??= string.Empty;
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

        public async Task<AddCustomerResponse> AddNewAsync(AddCustomerRequest request)
        {
            // We can use AutoMapper to map objects dynamically
            var customer = new Domain.Entities.Customers.Customer(request.FirstName,
                 request.LastName,
                 request.Address,
                 request.PostalCode);

            var repository = UnitOfWork.AsyncRepository<Domain.Entities.Customers.Customer>();
            await repository.AddAsync(customer);
            await UnitOfWork.SaveChangesAsync();

            var response = new AddCustomerResponse
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };

            return response;
        }

        public async Task<UpdateCustomerResponse> UpdateAsync(UpdateCustomerRequest request)
        {
            var repository = UnitOfWork.AsyncRepository<Domain.Entities.Customers.Customer>();

            var customer = await repository
                .GetAsync(x => x.Id == request.Id);

            if (customer != null)
            {
                customer.FirstName = request.FirstName;
                customer.LastName = request.LastName;
                customer.Address = request.Address;
                customer.PostalCode = request.PostalCode; 

                await repository.UpdateAsync(customer);
                await UnitOfWork.SaveChangesAsync();

                var response = new UpdateCustomerResponse
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                };

                return response;
            }

            throw new Exception("Customer was not found.");
        }

        public async Task<DeleteCustomerResponse> DeleteAsync(DeleteCustomerRequest request)
        {
            var repository = UnitOfWork.AsyncRepository<Domain.Entities.Customers.Customer>();

            var customer = await repository
                .GetAsync(x => x.Id == request.Id);

            if (customer != null)
            {
                var orderRepository = UnitOfWork.AsyncRepository<Domain.Entities.Orders.Order>();

                var ordersForDeletedCustomer = await orderRepository.ListAsync(x => x.CustomerId == customer.Id);

                if (ordersForDeletedCustomer.Count > 0)
                    throw new Exception("Related orders were created using this customer. Customer can be deleted.");

                await repository.DeleteAsync(customer);
                await UnitOfWork.SaveChangesAsync();

                var response = new DeleteCustomerResponse
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                };

                return response;
            }

            throw new Exception("Customer was not found.");
        }
    }
}
