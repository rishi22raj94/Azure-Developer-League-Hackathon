using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19_wld
{
    public class Constants
    {
        public string APIURL = "https://data.telangana.gov.in/api/action/datastore/search.json";
        public string WEATHERAPIURL = "http://api.weatherstack.com/";
        public string IPADDRESSAPIURL = "http://api.ipstack.com/";
        public string VACCINECENTERBYPIN = "https://cdn-api.co-vin.in/api/v2/appointment/sessions/public/calendarByPin";
        public string VALIDIPADDRESSAPIURL = "http://ip-api.com/json/";
        public string IPADDRESSAPIPARAMETERS_FORCURRENTLOCATION = "?access_key=2114997371d31ec3490301f5186f03fa";
        public string WEATHERAPIPARAMETERS_FORCURRENTLOCATION = "current?access_key=5408f7dc48a7700f24a45f483478031b&query=";
        public string RAILWAY_STATIONSURLPARAMETER = "?resource_id=e720aed4-33f8-4b3b-b847-3c2d86c3ca3a&limit=14";
        public string ROADSURLPARAMETER = "?resource_id=14f81966-4db8-4f57-8b5b-88969fd12843&limit=14";
        public string INDIACOVIDSTATUS = "https://api.covid19india.org/data.json";        
        public string DAILYCOVIDSTATUS = "https://api.covid19india.org/v4/min/timeseries.min.json";
        public string IPADDRESS = string.Empty;
    }
}
