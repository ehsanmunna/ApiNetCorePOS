using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corepos.Models.Product
{
    public class ProductViewDto : ProductCreateDto
    {
        public GroupViewDto Group { get; set; }
        public SupplierViewDto Supplier { get; set; }
        public MesurementUnitViewDto Unit { get; set; }
    }
}
