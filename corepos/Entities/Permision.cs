using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class Permision
    {
        public Permision()
        {
            UserPermision = new HashSet<UserPermision>();
        }

        public int Id { get; set; }
        public string PermisionName { get; set; }

        public ICollection<UserPermision> UserPermision { get; set; }
    }
}
