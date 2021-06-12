using System;
using System.Collections.Generic;
using System.Globalization;

namespace covid19_wld.Model
{
    public partial class IndiaStateDistrictWise
    {

        public class Rootobject
        {
            public Cases_Time_Series[] cases_time_series { get; set; }
            public Statewise[] statewise { get; set; }
            public Tested[] tested { get; set; }
        }

        public class Cases_Time_Series
        {
            public string dailyconfirmed { get; set; }
            public string dailydeceased { get; set; }
            public string dailyrecovered { get; set; }
            public string date { get; set; }
            public string totalconfirmed { get; set; }
            public string totaldeceased { get; set; }
            public string totalrecovered { get; set; }
        }

        public class Statewise
        {
            public string active { get; set; }
            public string confirmed { get; set; }
            public string deaths { get; set; }
            public string deltaconfirmed { get; set; }
            public string deltadeaths { get; set; }
            public string deltarecovered { get; set; }
            public string lastupdatedtime { get; set; }
            public string recovered { get; set; }
            public string state { get; set; }
            public string statecode { get; set; }
            public string statenotes { get; set; }
        }

        public class Tested
        {
            public string individualstestedperconfirmedcase { get; set; }
            public string positivecasesfromsamplesreported { get; set; }
            public string samplereportedtoday { get; set; }
            public string source { get; set; }
            public string testpositivityrate { get; set; }
            public string testsconductedbyprivatelabs { get; set; }
            public string testsperconfirmedcase { get; set; }
            public string totalindividualstested { get; set; }
            public string totalindividualsvaccinated { get; set; }
            public string totaldosesadministered { get; set; }
            public string totalpositivecases { get; set; }
            public string totalsamplestested { get; set; }
            public string updatetimestamp { get; set; }
        }
    }
}


