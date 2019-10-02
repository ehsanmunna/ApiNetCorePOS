using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class MeasurementUnit
    {
        public MeasurementUnit()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string UnitName { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
