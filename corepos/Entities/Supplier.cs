using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class Supplier
    {
        public Supplier()
        {
            Product = new HashSet<Product>();
        }

        public string Id { get; set; }
        public string PersonId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }

        public Person Person { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
