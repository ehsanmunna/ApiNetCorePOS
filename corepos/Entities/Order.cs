using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderSub = new HashSet<OrderSub>();
        }

        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public string EmployeeId { get; set; }
        public string ShippedTo { get; set; }

        public ICollection<OrderSub> OrderSub { get; set; }
    }
}
