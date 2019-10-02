using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class Stock
    {
        

        public string StockId { get; set; }
        public string ProductId { get; set; }
        public int? Reorderlavel { get; set; }

        public Product Product { get; set; }

    }
}
