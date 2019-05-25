using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class PosUser
    {
        public PosUser()
        {
            RoleUserMap = new HashSet<RoleUserMap>();
            UserPermision = new HashSet<UserPermision>();
        }

        public string UserId { get; set; }
        public string PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Person Person { get; set; }
        public ICollection<RoleUserMap> RoleUserMap { get; set; }
        public ICollection<UserPermision> UserPermision { get; set; }
    }
}
