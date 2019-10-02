using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class ProductGroup
    {
        public ProductGroup()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
