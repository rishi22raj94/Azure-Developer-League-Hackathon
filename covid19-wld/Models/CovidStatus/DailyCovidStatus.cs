using System;
using System.Collections.Generic;
using System.Globalization;

namespace covid19_wld.Model.CovidStatus
{
    public class DailyCovidStatus
    {
        public States_Daily[] states_daily { get; set; }
        public class States_Daily
        {
            public string an { get; set; }
            public string ap { get; set; }
            public string ar { get; set; }
            public string @as { get; set; }
            public string br { get; set; }
            public string ch { get; set; }
            public string ct { get; set; }
            public string date { get; set; }
            public string dd { get; set; }
            public string dl { get; set; }
            public string dn { get; set; }
            public string ga { get; set; }
            public string gj { get; set; }
            public string hp { get; set; }
            public string hr { get; set; }
            public string jh { get; set; }
            public string jk { get; set; }
            public string ka { get; set; }
            public string kl { get; set; }
            public string la { get; set; }
            public string ld { get; set; }
            public string mh { get; set; }
            public string ml { get; set; }
            public string mn { get; set; }
            public string mp { get; set; }
            public string mz { get; set; }
            public string nl { get; set; }
            public string or { get; set; }
            public string pb { get; set; }
            public string py { get; set; }
            public string rj { get; set; }
            public string sk { get; set; }
            public string status { get; set; }
            public string tg { get; set; }
            public string tn { get; set; }
            public string tr { get; set; }
            public string tt { get; set; }
            public string up { get; set; }
            public string ut { get; set; }
            public string wb { get; set; }
        }
    }
}
