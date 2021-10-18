using API.DTOs.Product;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Product
{
    public class ProductService : BaseService
    {
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<List<ProductInfoDTO>> SearchAsync(GetProductRequest request)
        {
            var repository = UnitOfWork.AsyncRepository<Domain.Entities.Products.Product>();
            request.Search ??= string.Empty;
            var products = await repository
                .ListAsync(x => x.Name.Contains(request.Search));

            var ProductDTOs = products.Select(_ => new ProductInfoDTO
            {
                Id = _.Id,
                Name = _.Name,
                Price = _.Price
            }).ToList();

            return ProductDTOs;
        }


        public async Task<AddProductResponse> AddNewAsync(AddProductRequest request)
        {
            ValidateProductPrice(request.Price);

            // We can use AutoMapper to map objects dynamically
            var product = new Domain.Entities.Products.Product(request.Name, request.Price);

            var repository = UnitOfWork.AsyncRepository<Domain.Entities.Products.Product>();
            await repository.AddAsync(product);
            await UnitOfWork.SaveChangesAsync();

            var response = new AddProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            return response;
        }

        public async Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest request)
        {
            ValidateProductPrice(request.Price);

            var repository = UnitOfWork.AsyncRepository<Domain.Entities.Products.Product>();

            var Product = await repository
                .GetAsync(x => x.Id == request.Id);

            if (Product != null)
            {
                Product.Name = request.Name;
                Product.Price = request.Price;

                await repository.UpdateAsync(Product);
                await UnitOfWork.SaveChangesAsync();

                var response = new UpdateProductResponse
                {
                    Id = Product.Id,
                    Name = Product.Name,
                    Price = Product.Price
                };

                return response;
            }

            throw new Exception("Product was not found.");
        }


        public async Task<DeleteProductResponse> DeleteAsync(DeleteProductRequest request)
        {
            var repository = UnitOfWork.AsyncRepository<Domain.Entities.Products.Product>();

            var product = await repository
                .GetAsync(x => x.Id == request.Id);

            if (product != null)
            {
                var orderItemRepository =  UnitOfWork.AsyncRepository<Domain.Entities.Orders.OrderItem>();

                var orderItemsForDeletedProduct = await orderItemRepository.ListAsync(x => x.ProductId == product.Id);

                if(orderItemsForDeletedProduct.Count > 0)
                    throw new Exception("Related orders were created using this product. Product can be deleted.");

                await repository.DeleteAsync(product);
                await UnitOfWork.SaveChangesAsync();

                var response = new DeleteProductResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                };

                return response;
            }

            throw new Exception("Product was not found.");
        }

        #region Helping methods

        private void ValidateProductPrice(double price)
        {
            if (price <= 0)
            {
                throw new Exception("Price is equals or less than 0");
            }
        }

        #endregion

    }
}
