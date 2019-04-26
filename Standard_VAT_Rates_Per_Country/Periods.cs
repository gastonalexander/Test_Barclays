using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard_VAT_Rates_Per_Country
{
    public class Periods
    {
        public string effective_from { get; set; }
        public string rates { get; set; }
        public string super_reduced { get; set; }
        public string reduced { get; set; }
        public string standard { get; set; }
    }
}
