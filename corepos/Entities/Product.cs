using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class Product
    {
        public Product()
        {
            Stock = new HashSet<Stock>();
        }

        public string ProdId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? RetailPrice { get; set; }
        public decimal? WholeSalePrice { get; set; }

        public ICollection<Stock> Stock { get; set; }
    }
}
