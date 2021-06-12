using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19_wld.Models
{
    public class Chart
    {
        public List<int> tested { get; set; }
        public List<int> vaccinated { get; set; }
        public List<int> confirmed { get; set; }
        public List<int> deceased { get; set; }
        public List<int> recovered { get; set; }
        public List<string> dates { get; set; }
        public List<string> tested_dates { get; set; }        
    }
}
