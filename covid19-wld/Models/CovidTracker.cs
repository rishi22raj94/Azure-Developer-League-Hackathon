using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19_wld.Model
{
    public class CovidTracker
    {
        public string Confirmed { get; set; }

        public string Recovered { get; set; }

        public string Deceased { get; set; }

        public string Tested { get; set; }

        public string AdminVaccinated { get; set; }

        public int Vaccinated1 { get; set; }

        public int Vaccinated2 { get; set; }

        public string Vaccinated { get; set; }
    }
}
