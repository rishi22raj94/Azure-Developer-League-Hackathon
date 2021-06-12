using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19_wld.Models
{
    public class LiveCases
    {
        public string active { get; set; }
        public string confirmed { get; set; }
        public string deceased { get; set; }
        public string recovered { get; set; }
        public string vaccinated { get; set; }
        public string lastupdatedtime { get; set; }
    }
}
