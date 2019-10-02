using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corepos.Models.Product
{
    public class ProductCreateDto
    {
        public string ProdId { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public int UnitId { get; set; }
        public string SupplierId { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal SalsePrice { get; set; }
        public decimal? Discount { get; set; }
        public string Description { get; set; }
    }
}
