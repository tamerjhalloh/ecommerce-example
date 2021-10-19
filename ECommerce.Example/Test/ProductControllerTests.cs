using API.Controllers;
using API.DTOs.Product;
using API.Services.Product;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Test
{
    public class ProductControllerTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AddProduct_ThrowsException_IFProductNameIsEmpty()
        {
            // Arrange
            var request = new AddProductRequest { Name = "", Price = 10 };
            var productDataStore = A.Fake<ProductService>(); 
            var productController = new ProductController(productDataStore);

            // Act            
            Task act() => productController.Add(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }

        [Test]
        public void AddProduct_ThrowsException_IFProductPriceIsZero()
        {
            // Arrange
            var request = new AddProductRequest { Name = "test", Price = 0 };
            var productDataStore = A.Fake<ProductService>();
            var productController = new ProductController(productDataStore);

            // Act            
            Task act() => productController.Add(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }

        [Test]
        public void UpdateProduct_ThrowsException_IFProductIdIsEmpty()
        {
            // Arrange
            var request = new UpdateProductRequest {   Name = "Test", Price = 10 };
            var productDataStore = A.Fake<ProductService>();
            var productController = new ProductController(productDataStore);

            // Act            
            Task act() => productController.Update(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }

        [Test]
        public void UpdateProduct_ThrowsException_IFProductNameIsEmpty()
        {
            // Arrange
            var request = new UpdateProductRequest { Id = Guid.Parse("b84ab1d8-affe-451a-94a3-538d5ae08eb8"), Name = "", Price = 10 };
            var productDataStore = A.Fake<ProductService>();
            var productController = new ProductController(productDataStore);

            // Act            
            Task act() => productController.Update(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }

        [Test]
        public void UpdateProduct_ThrowsException_IFProductPriceIsZero()
        {
            // Arrange
            var request = new UpdateProductRequest {Id = Guid.Parse("b84ab1d8-affe-451a-94a3-538d5ae08eb8"), Name = "test", Price = 0 };
            var productDataStore = A.Fake<ProductService>();
            var productController = new ProductController(productDataStore);

            // Act            
            Task act() => productController.Update(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }

        [Test]
        public void DeleteProduct_ThrowsException_IFProductIdIsEmpty()
        {
            // Arrange
            var request = new DeleteProductRequest { };
            var productDataStore = A.Fake<ProductService>();
            var productController = new ProductController(productDataStore);

            // Act            
            Task act() => productController.Delete(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }
    }
}
