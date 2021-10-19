using API.Controllers;
using API.DTOs.Customer;
using API.Services.Customer;
using API.Services.Order;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Test
{
    public class CustomerControllerTests
    {
        

        [SetUp]
        public void Setup()
        { 

        }  

        [Test]
        public void AddCustomer_ThrowsException_IFCustomerFirstNameIsEmpty()
        {
            // Arrange
            var request = new AddCustomerRequest { FirstName = "", LastName = "Test", Address = "Test" };
            var customerDataStore = A.Fake<CustomerService>();
            var orderDataStore = A.Fake<OrderService>();
            var customerController = new CustomerController(customerDataStore, orderDataStore);

            // Act            
            Task act() => customerController.Add(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }

        [Test]
        public void AddCustomer_ThrowsException_IFCustomerLastNameIsEmpty()
        {
            // Arrange
            var request = new AddCustomerRequest { FirstName = "Test", LastName = "", Address = "Test" };
            var customerDataStore = A.Fake<CustomerService>();
            var orderDataStore = A.Fake<OrderService>();
            var customerController = new CustomerController(customerDataStore, orderDataStore);

            // Act            
            Task act() => customerController.Add(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }

        [Test]
        public void AddCustomer_ThrowsException_IFCustomerAddressIsEmpty()
        {
            // Arrange
            var request = new AddCustomerRequest { FirstName = "Test", LastName = "Test", Address = "" };
            var customerDataStore = A.Fake<CustomerService>();
            var orderDataStore = A.Fake<OrderService>();
            var customerController = new CustomerController(customerDataStore, orderDataStore);

            // Act            
            Task act() => customerController.Add(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }


        [Test]
        public void UpdateCustomer_ThrowsException_IFCustomerIdIsInvalid()
        {
            // Arrange
            var request = new UpdateCustomerRequest {  FirstName = "Test", LastName = "Test", Address = "Test" };
            var customerDataStore = A.Fake<CustomerService>();
            var orderDataStore = A.Fake<OrderService>();
            var customerController = new CustomerController(customerDataStore, orderDataStore);

            // Act            
            Task act() => customerController.Update(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }

        [Test]
        public void UpdateCustomer_ThrowsException_IFCustomerFirstNameIsEmpty()
        {
            // Arrange
            var request = new UpdateCustomerRequest { Id = Guid.Parse("b84ab1d8-affe-451a-94a3-538d5ae08eb8"), FirstName = "", LastName = "Test", Address = "Test" };
            var customerDataStore = A.Fake<CustomerService>();
            var orderDataStore = A.Fake<OrderService>();
            var customerController = new CustomerController(customerDataStore, orderDataStore);

            // Act            
            Task act() => customerController.Update(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }

        [Test]
        public void UpdateCustomer_ThrowsException_IFCustomerLastNameIsEmpty()
        {
            // Arrange
            var request = new UpdateCustomerRequest { Id = Guid.Parse("b84ab1d8-affe-451a-94a3-538d5ae08eb8"), FirstName = "Test", LastName = "", Address = "Test" };
            var customerDataStore = A.Fake<CustomerService>();
            var orderDataStore = A.Fake<OrderService>();
            var customerController = new CustomerController(customerDataStore, orderDataStore);

            // Act            
            Task act() => customerController.Update(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }

        [Test]
        public void UpdateCustomer_ThrowsException_IFCustomerAddressIsEmpty()
        {
            // Arrange
            var request = new UpdateCustomerRequest { Id = Guid.Parse("b84ab1d8-affe-451a-94a3-538d5ae08eb8"), FirstName = "Test", LastName = "Test", Address = "" };
            var customerDataStore = A.Fake<CustomerService>();
            var orderDataStore = A.Fake<OrderService>();
            var customerController = new CustomerController(customerDataStore, orderDataStore);

            // Act            
            Task act() => customerController.Update(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }

        [Test]
        public void GetCustomerOrders_ThrowsException_IFCustomerIdIsEmpty()
        {
            // Arrange
            var request = new AddCustomerRequest { };
            var customerDataStore = A.Fake<CustomerService>();
            var orderDataStore = A.Fake<OrderService>();
            var customerController = new CustomerController(customerDataStore, orderDataStore);

            // Act            
            Task act() => customerController.Add(request);

            //Assert
            Assert.That(act, Throws.TypeOf<Exception>());
        }
    }
}