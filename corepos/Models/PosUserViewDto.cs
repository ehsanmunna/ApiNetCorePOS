using corepos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corepos.Models
{
    public class PosUserViewDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PersonId { get; set; }
        public PersonDto Person { get; set; }
        
    }
}
