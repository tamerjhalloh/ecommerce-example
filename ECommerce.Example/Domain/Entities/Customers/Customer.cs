using Domain.Base;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Customers
{
    public partial class Customer : BaseEntity<Guid>
    {
        public Customer()
        {
            Orders = new HashSet<Orders.Order>();
        }

        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Address { get;  set; }
        public string PostalCode { get;  set; }

        public virtual ICollection<Orders.Order> Orders { get; set; }
    }
}
