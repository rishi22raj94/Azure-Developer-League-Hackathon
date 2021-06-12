using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19_wld.Model
{
    public class UserData
    {            
            public string statename { get; set; }           
            public string datetime { get; set; }
            public bool confirmed { get; set; }
            public bool recovered { get; set; }
            public bool decreased { get; set; }
            public bool default_checkbox { get; set; }
            public bool userinputerror { get; set; }        
    }
}
