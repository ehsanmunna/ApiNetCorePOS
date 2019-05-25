using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class Item
    {
        public Item()
        {
            OrderSub = new HashSet<OrderSub>();
        }

        public string ItemId { get; set; }
        public string ProductId { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? SalsePrice { get; set; }
        public int? Reorderlavel { get; set; }
        public string Description { get; set; }

        public Product Product { get; set; }
        public ICollection<OrderSub> OrderSub { get; set; }
    }
}
