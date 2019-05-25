using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class UserPermision
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? PermisionId { get; set; }

        public Permision Permision { get; set; }
        public PosUser User { get; set; }
    }
}
