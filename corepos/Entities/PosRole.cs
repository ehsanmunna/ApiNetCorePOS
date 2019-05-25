using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class PosRole
    {
        public PosRole()
        {
            RoleUserMap = new HashSet<RoleUserMap>();
        }

        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<RoleUserMap> RoleUserMap { get; set; }
    }
}
