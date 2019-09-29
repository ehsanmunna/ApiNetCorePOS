using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corepos.Models
{
    public class CustomerCreateDto
    {
        public string CustId { get; set; }
        public string PersonId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public PersonViewDto Person { get; set; }
    }
}
