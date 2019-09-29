using corepos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corepos.Models
{
    public class PosUserUpdateDto
    {
        public string UserName { get; set; }
        public PersonUpdateDto Person { get; set; }
    }
}
