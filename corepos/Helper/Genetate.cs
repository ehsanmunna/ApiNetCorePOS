using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corepos.Helper
{
    public class Genetate
    {
        public string GenerateNumber(string prefix = "")
        {
            if (prefix != "")
            {
                prefix = prefix + "-";
            }
            return prefix + GetDateTime();
        }

        static string GetDateTime()
        {
            var datetime = DateTime.Now;
            return datetime.ToString("yyyyMMddHHmmss");
        }
    }
}
