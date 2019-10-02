using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class SalesSub
    {
        public Guid Id { get; set; }
        public string SalseId { get; set; }
        public string ItemId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? DiscountInPercentage { get; set; }
        public decimal? DiscountInAmount { get; set; }
        public decimal? Vat { get; set; }

        public Product Item { get; set; }
        public SalesMain Salse { get; set; }
    }
}
