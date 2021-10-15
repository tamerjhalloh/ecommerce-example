using Domain.Base;
using System;
using System.Linq;

namespace Domain.Entities.Customers
{
    public partial class Customer : IAggregateRoot
    {
        public Customer(string firstName,
            string lastName,
            string address,
            string postalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PostalCode = postalCode;
        }


        public void Update(string firstName,
           string lastName,
           string address,
           string postalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PostalCode = postalCode;
        }

        //public Orders.Order AddOrder(Orders.Order order)
        //{
        //    var exists = Orders.Any(x => x.Id == order.Id);

        //    if (exists)
        //        throw new Exception("Same order for this customer already exist.");


        //}
    }
}
