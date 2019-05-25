using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class Person
    {
        public Person()
        {
            Customer = new HashSet<Customer>();
            PosUser = new HashSet<PosUser>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }

        public ICollection<Customer> Customer { get; set; }
        public ICollection<PosUser> PosUser { get; set; }
    }
}
