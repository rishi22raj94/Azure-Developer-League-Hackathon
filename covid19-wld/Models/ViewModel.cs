using covid19_wld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19_wld.Model
{
    public class ViewModel
    {
        public Location_Weather.ClientIPAddress IPAddress { get; set; }
        public Location_Weather.Weather Weather { get; set; }
        public Location_Weather.ValidIPAddress ValidIPAddress { get; set; }
        public MapLocation MapLocation { get; set; }
        //public int? maxtemp { get; set; }
        //public int? mintemp { get; set; }
    }

}




