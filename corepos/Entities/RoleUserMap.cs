using System;
using System.Collections.Generic;

namespace corepos.Entities
{
    public partial class RoleUserMap
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public PosRole Role { get; set; }
        public PosUser User { get; set; }
    }
}
