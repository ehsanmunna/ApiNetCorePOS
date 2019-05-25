using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class Product
    {
        public Product()
        {
            Item = new HashSet<Item>();
        }

        public string ProdId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Item> Item { get; set; }
    }
}
