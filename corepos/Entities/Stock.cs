using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class Stock
    {
        public Stock()
        {
            OrderSub = new HashSet<OrderSub>();
        }

        public string StockId { get; set; }
        public string ProductId { get; set; }
        public int? Reorderlavel { get; set; }

        public Product Product { get; set; }
        public ICollection<OrderSub> OrderSub { get; set; }
    }
}
