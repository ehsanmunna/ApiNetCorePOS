using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class Customer
    {
        public string CustId { get; set; }
        public string PersonId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Person Person { get; set; }
    }
}
