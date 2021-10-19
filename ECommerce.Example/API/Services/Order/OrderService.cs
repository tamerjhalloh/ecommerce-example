using API.DTOs.Order;
using API.DTOs.Product;
using API.Extensions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Services.Order
{
    public class OrderService : BaseService
    {
        public OrderService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<List<GetOrderResponse>> SearchAsync(GetOrderRequest request)
        {
            var repository = UnitOfWork.AsyncRepository<Domain.Entities.Orders.Order>();

            Expression<Func<Domain.Entities.Orders.Order, bool>> expression = x => 1 == 1;

            if (request.CustomerId != Guid.Empty)
                expression = expression.AndAlso(x => x.CustomerId == request.CustomerId);

            if (request.OrderTimeFrom.Year > 2000)
                expression = expression.AndAlso(x => x.OrderTime >= request.OrderTimeFrom);

            if (request.OrderTimeTo.Year > 2000)
                expression = expression.AndAlso(x => x.OrderTime <= request.OrderTimeTo);

            var orders = await repository.ListAsync(expression, request.Page, request.Size, "Customer;Items;Items.Product");

            var orderDTOs = new List<GetOrderResponse>();

            foreach (var order in orders)
            {
                var orderDTO = new GetOrderResponse
                {
                    Id = order.Id,
                    Customer = new DTOs.Customer.CustomerInfoDTO
                    {
                        Id = order.Customer.Id,
                        FirstName = order.Customer.FirstName,
                        LastName = order.Customer.LastName,
                        Address = order.Customer.Address,
                        PostalCode = order.Customer.PostalCode
                    },
                    OrderTime = order.OrderTime,
                    TotalAmount = order.TotalAmount,
                    Items = new List<OrderItemInfoDTO>()
                };

                foreach (var item in order.Items)
                {
                    var orderItem = new OrderItemInfoDTO
                    {
                        Id = item.Id,
                        Quantity = item.Quantity,
                    };
                    orderItem.Product = new ProductInfoDTO
                    {
                        Id = item.Product.Id,
                        Name = item.Product.Name,
                        Price = item.Product.Price
                    };

                    orderDTO.Items.Add(orderItem);
                }

                orderDTOs.Add(orderDTO);
            }

            return orderDTOs;
        }

        public async Task<AddOrderResponse> AddNewAsync(AddOrderRequest request)
        {
            if (request.CustomerId == Guid.Empty)
                throw new Exception("Customer Id is empty");

            if (request.Items == null || !request.Items.Any())
                throw new Exception("Order Items has to be one or more");

            var customerRepository = UnitOfWork.AsyncRepository<Domain.Entities.Customers.Customer>();

            var customer = await customerRepository.GetAsync(x => x.Id == request.CustomerId);

            if (customer == null)
                throw new Exception("Customer was not found.");


            var productRepository = UnitOfWork.AsyncRepository<Domain.Entities.Products.Product>();
            var orderProducts = new List<Domain.Entities.Products.Product>();
            foreach (var item in request.Items)
            {
                if (item.Quantity < 1)
                    throw new Exception($"Product with {item.ProductId} has invalid quantity.");

                var product = await productRepository.GetAsync(x => x.Id == item.ProductId);

                if (product == null)
                    throw new Exception($"Product with {item.ProductId} was not found.");

                orderProducts.Add(product);
            }

            double total = request.Items.Sum(x => x.Quantity * (orderProducts.FirstOrDefault(y => y.Id == x.ProductId).Price));

            var order = new Domain.Entities.Orders.Order(request.CustomerId, DateTime.Now, total);

            foreach (var item in request.Items)
            {
                order.Items.Add(new Domain.Entities.Orders.OrderItem(item.ProductId, item.Quantity));
            }

            var repository = UnitOfWork.AsyncRepository<Domain.Entities.Orders.Order>();
            await repository.AddAsync(order);
            await UnitOfWork.SaveChangesAsync();

            var response = new AddOrderResponse
            {
                Id = order.Id,
                Customer = new DTOs.Customer.CustomerInfoDTO
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    PostalCode = customer.PostalCode
                },
                OrderTime = order.OrderTime,
                TotalAmount = order.TotalAmount,
                Items = new List<OrderItemInfoDTO>()
            };

            foreach (var item in order.Items)
            {
                var orderItem = new OrderItemInfoDTO
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                };

                var product = item.Product ?? orderProducts.FirstOrDefault(y => y.Id == item.ProductId);

                orderItem.Product = new ProductInfoDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                };

                response.Items.Add(orderItem);
            }

            return response;
        }


        #region Helping Methods

        #endregion
    }
}
