using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corepos.Models
{
    public class SupplierCreateDto
    {
        public string Id { get; set; }
        public string PersonId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }

        public PersonViewDto Person { get; set; }
    }
}
