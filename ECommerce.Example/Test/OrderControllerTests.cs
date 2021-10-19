using API.Controllers;
using API.DTOs.Order;
using API.Services.Order;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class OrderControllerTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AddOrder_ThrowsException_IFCustomerIdIsEmpty()
        {
            // Arrange
            var request = new AddOrderRequest { };
            var orderDataStore = A.Fake<OrderService>();
            var orderController = new OrderController(orderDataStore);

            // Act            
            Task act() => orderController.Add(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }

        [Test]
        public void AddOrder_ThrowsException_IFItemsLessThanOne()
        {
            // Arrange
            var request = new AddOrderRequest { CustomerId = Guid.Parse("b84ab1d8-affe-451a-94a3-538d5ae08eb8") };
            var orderDataStore = A.Fake<OrderService>();
            var orderController = new OrderController(orderDataStore);

            // Act            
            Task act() => orderController.Add(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }
    }
}
