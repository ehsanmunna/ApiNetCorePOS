using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class SalesMain
    {
        public SalesMain()
        {
            SalesSub = new HashSet<SalesSub>();
        }

        public string SalesId { get; set; }
        public string RefNo { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? TotalDue { get; set; }
        public decimal? TotalReceive { get; set; }
        public decimal? TotalChangeAmount { get; set; }

        public ICollection<SalesSub> SalesSub { get; set; }
    }
}
