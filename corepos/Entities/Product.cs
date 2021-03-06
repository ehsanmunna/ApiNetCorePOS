﻿using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class Product
    {
        public Product()
        {
            SalesSub = new HashSet<SalesSub>();
        }

        public string ProdId { get; set; }
        public string Name { get; set; }
        public decimal? Quantity { get; set; }
        public int GroupId { get; set; }
        public int UnitId { get; set; }
        public string SupplierId { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal SalsePrice { get; set; }
        public decimal? Discount { get; set; }
        public string Description { get; set; }

        public ProductGroup Group { get; set; }
        public Supplier Supplier { get; set; }
        public MeasurementUnit Unit { get; set; }
        public ICollection<SalesSub> SalesSub { get; set; }
    }
}
