using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class OrderSub
    {
        public Guid OrderSubId { get; set; }
        public string OrderId { get; set; }
        public string ItemId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Discount { get; set; }

        public Stock Item { get; set; }
        public Order Order { get; set; }
    }
}
