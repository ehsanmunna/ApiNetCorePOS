using corepos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corepos.Models.Sales
{
    public class SalseCreateDto
    {
        
        public string RefNo { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? TotalDue { get; set; }
        public decimal? TotalReceive { get; set; }
        public decimal? TotalChangeAmount { get; set; }
        public ICollection<SalesSubCreateDto> SalesSub { get; set; }
    }
}
