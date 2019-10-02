using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corepos.Helper
{
    public class GenerateIds
    {

        public string GetPersonId()
        {
            return new Genetate().GenerateNumber("P");
        }

        public string GetSupplierId()
        {
            return new Genetate().GenerateNumber("S");
        }
        public string GetCustomerId()
        {
            return new Genetate().GenerateNumber("C");
        }
        public string GetProductId()
        {
            return new Genetate().GenerateNumber();
        }
        public string GetSalseId()
        {
            return new Genetate().GenerateNumber("Sl");
        }
    }
}
