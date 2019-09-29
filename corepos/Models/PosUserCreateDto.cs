using corepos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corepos.Models
{
    public class PosUserCreateDto : PosUserViewDto
    {
        public string Password { get; set; }

    }
}
