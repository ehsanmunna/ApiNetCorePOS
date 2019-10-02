using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corepos.Models.Sales
{
    public class SalesSubCreateDto
    {
        public string SalseId { get; set; }
        public string ItemId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? DiscountInPercentage { get; set; }
        public decimal? DiscountInAmount { get; set; }
        public decimal? Vat { get; set; }
        public Product.ProductViewDto Item { get; set; }
    }
}
