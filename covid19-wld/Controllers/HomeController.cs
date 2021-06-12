using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using covid19_wld.Model;
using covid19_wld.Model.CovidStatus;
using covid19_wld.Models;
using Microsoft.ApplicationInsights;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;
using Azure.Identity;
using System.Globalization;
using System.Text;
using covid19_wld.Models.CovidStatus;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading;
using System.Net;

namespace covid19_wld.Controllers
{
    public class HomeController : Controller
    {
        private Constants apivalues;
        private TelemetryClient telemetry;
        private static string Railway_StationsURLParameter;
        private static string Weather_ForCurrentLocation;
        private static string RoadsURLParameter;
        private static string URL;
        private readonly IHttpContextAccessor _accessor;
        private static string WeatherURL;
        private static string IPAddressURL;
        private static string VaccineCenterByPin;
        private static string ValidIPAddressURL;
        private static string IPAddress_AccessKey;
        private static string IndiaCovidStatus;
        private static string DailyCovidStatus;
        private ViewModelCovid covid;
        private Chart chart;
        private CSVTesting csv_testing;
        private LiveCases live;
        private VaccineCenterByPin.Center vaccineCenterByPin;
        private CovidTracker covidTrackerModel;
        private UserData userdatadetails;
        private readonly ILogger<HomeController> _logger;
        public CustomTelemetry clientipaddress;



        public HomeController(IHttpContextAccessor accessor, ILogger<HomeController> logger, TelemetryClient telemetry)
        {
            _logger = logger;
            this.telemetry = telemetry;
            covid = new ViewModelCovid();
            chart = new Chart();
            csv_testing = new CSVTesting();
            live = new LiveCases();
            vaccineCenterByPin = new VaccineCenterByPin.Center();
            covidTrackerModel = new CovidTracker();
            userdatadetails = new UserData();
            _accessor = accessor;
            clientipaddress = new CustomTelemetry(_accessor);
            apivalues = new Constants();
            Railway_StationsURLParameter = apivalues.RAILWAY_STATIONSURLPARAMETER;
            Weather_ForCurrentLocation = apivalues.WEATHERAPIPARAMETERS_FORCURRENTLOCATION;
            IPAddressURL = apivalues.IPADDRESSAPIURL;
            VaccineCenterByPin = apivalues.VACCINECENTERBYPIN;
            ValidIPAddressURL = apivalues.VALIDIPADDRESSAPIURL;
            IPAddress_AccessKey = apivalues.IPADDRESSAPIPARAMETERS_FORCURRENTLOCATION;
            RoadsURLParameter = apivalues.ROADSURLPARAMETER;
            URL = apivalues.APIURL;
            WeatherURL = apivalues.WEATHERAPIURL;
            IndiaCovidStatus = apivalues.INDIACOVIDSTATUS;
            DailyCovidStatus = apivalues.DAILYCOVIDSTATUS;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                //var DailyCovidStatus = await GetDailyCovidStatus();

                IndiaStateDistrictWise.Rootobject data = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(URL);
                    //HTTP GET
                    HttpResponseMessage responseTask = client.GetAsync(IndiaCovidStatus).Result;

                    if (responseTask.IsSuccessStatusCode)
                    {
                        var customerJsonString = await responseTask.Content.ReadAsStringAsync();
                        var dataObjects = JsonConvert.DeserializeObject<IndiaStateDistrictWise.Rootobject>(customerJsonString);
                        data = dataObjects;
                        client.Dispose();
                        covid.IndiaStateDistrictWise = data;
                        //covid.DailyCovidStatus = DailyCovidStatus;

                        var tested_results = (from testedresult in covid.IndiaStateDistrictWise.tested.Select((testeddetails) => new { testeddetails })
                                              select new
                                              {
                                                  details = testedresult.testeddetails,
                                                  tested_date = testedresult.testeddetails.updatetimestamp,
                                                  live_tested_numbers = testedresult.testeddetails.totalsamplestested,
                                                  live_vaccinated_numbers = testedresult.testeddetails.totaldosesadministered
                                              }).Distinct().ToList();

                        var live_cases_results = (from liveresult in covid.IndiaStateDistrictWise.cases_time_series.Select((livedetails) => new { livedetails })
                                                  select new
                                                  {
                                                      details = liveresult.livedetails,
                                                      livedetails_confirmed = liveresult.livedetails.totalconfirmed,
                                                      livedetails_deceased = liveresult.livedetails.totaldeceased,
                                                      livedetails_recovered = liveresult.livedetails.totalrecovered,
                                                      livedetails_date = liveresult.livedetails.date
                                                  }).Distinct().ToList();

                        //var live_tested_cases = (from testedresultnumbers in tested_results.Select((testeddetailsnumbers) => new { testeddetailsnumbers })
                        //                         select new
                        //                         {
                        //                             tested_numbers = testedresultnumbers.testeddetailsnumbers.live_tested_numbers,
                        //                             tested_date = testedresultnumbers.testeddetailsnumbers.tested_date
                        //                         }).Distinct().ToDictionary(mc => mc.tested_date.ToString(),
                        //                                     mc => mc.tested_numbers.ToString(),
                        //                                     StringComparer.OrdinalIgnoreCase);

                        //string csv_livedetails_confirmed = string.Join(",", live_cases_results.TakeLast(7).Select(x => x.livedetails_confirmed).ToList());
                        //string csv_livedetails_date = string.Join(",", live_cases_results.TakeLast(7).Select(x => x.livedetails_date.Remove(6,2)).ToList());
                        //csv_testing.csv_confirmed = (csv_livedetails_confirmed.Trim(',').Split(',').ToList()).ConvertAll(int.Parse);
                        //csv_testing.csv_dates = csv_livedetails_date.Trim(',').Split(',').ToList();

                        List<int> totalconfirmed = new List<int>();
                        foreach (var confirm in live_cases_results.TakeLast(7))
                        {
                            if (confirm.livedetails_confirmed != string.Empty)
                                totalconfirmed.Add(Int32.Parse(confirm.livedetails_confirmed));
                        }

                        List<int> totaldeceased = new List<int>();
                        foreach (var deceased in live_cases_results.TakeLast(7))
                        {
                            if (deceased.livedetails_deceased != string.Empty)
                                totaldeceased.Add(Int32.Parse(deceased.livedetails_deceased));
                        }

                        List<int> totalrecovered = new List<int>();
                        foreach (var recovered in live_cases_results.TakeLast(7))
                        {
                            if (recovered.livedetails_recovered != string.Empty)
                                totalrecovered.Add(Int32.Parse(recovered.livedetails_recovered));
                        }

                        List<string> dates_data = new List<string>();
                        foreach (var date in live_cases_results.TakeLast(7))
                        {
                            if (date.livedetails_date != string.Empty)
                            {
                                string MyString = date.livedetails_date;
                                string removed_date = string.Empty;
                                var dateformat = MyString.ToCharArray();

                                if (dateformat[1] == ' ')
                                {
                                    removed_date = MyString.Length <= 3 ? MyString : MyString.Substring(0, 5);
                                }
                                else
                                {
                                    removed_date = MyString.Length <= 3 ? MyString : MyString.Substring(0, 6);
                                }

                                dates_data.Add(removed_date);
                            }

                        }

                        var live_vaccinated_cases = (from testedresultnumbers in tested_results.Select((testeddetailsnumbers) => new { testeddetailsnumbers }).Where(c => c.testeddetailsnumbers.live_vaccinated_numbers != null)
                                                     select new
                                                     {
                                                         vaccinated_numbers = testedresultnumbers.testeddetailsnumbers.live_vaccinated_numbers
                                                     }).Distinct().ToList();

                        List<int> vaccinated = new List<int>();
                        foreach (var vaccine in live_vaccinated_cases.TakeLast(7))
                        {
                            if (vaccine.vaccinated_numbers != string.Empty)
                                vaccinated.Add(Int32.Parse(vaccine.vaccinated_numbers));
                        }

                        var live_tested_cases = (from testedresultnumbers in tested_results.Select((testeddetailsnumbers) => new { testeddetailsnumbers }).Where(c => c.testeddetailsnumbers.live_tested_numbers != null)
                                                 select new
                                                 {
                                                     tested_numbers = testedresultnumbers.testeddetailsnumbers.live_tested_numbers
                                                 }).Distinct().ToList();

                        List<int> tested = new List<int>();
                        foreach (var test in live_tested_cases.TakeLast(7))
                        {
                            if (test.tested_numbers != string.Empty)
                                tested.Add(Int32.Parse(test.tested_numbers));
                        }

                        var live_date_cases = (from testedresultnumbers in tested_results.Select((testeddetailsnumbers) => new { testeddetailsnumbers })
                                               select new
                                               {
                                                   tested_date = testedresultnumbers.testeddetailsnumbers.tested_date
                                               }).Distinct().ToList();

                        List<string> dates_tested = new List<string>();
                        foreach (var date in live_date_cases.TakeLast(7))
                        {
                            if (date.tested_date != string.Empty)
                            {
                                string MyString = date.tested_date;
                                string removed_date = MyString.Remove(10, 9);
                                string[] correct_dataformat = removed_date.Split('/');
                                int year = Convert.ToInt32(correct_dataformat[2]);
                                int month = Convert.ToInt32(correct_dataformat[1]);
                                int day = Convert.ToInt32(correct_dataformat[0]);
                                DateTime dob = new DateTime(year, month, day);
                                string date_dob = dob.ToString("D");
                                string date_value = date_dob.Length <= 3 ? date_dob : date_dob.Substring(0, 6);
                                dates_tested.Add(date_value);
                            }

                        }

                        var state_names_codes = (from result in covid.IndiaStateDistrictWise.statewise.Select((statedetails) => new { statedetails })
                                                 select new
                                                 {
                                                     details = result.statedetails,
                                                     code = result.statedetails.statecode
                                                 }).Distinct().ToList();

                        var userinput_statenamesandcode = (from r in state_names_codes.Where(r => r.code.Equals("TT"))
                                                           select new
                                                           {
                                                               state_details = r,
                                                               state_code = r.code.ToLower()
                                                           }).FirstOrDefault();

                        if (userinput_statenamesandcode != null)
                        {
                            live.active = FormatNumber(Convert.ToInt32(userinput_statenamesandcode.state_details.details.active));
                            live.confirmed = FormatNumber(Convert.ToInt32(userinput_statenamesandcode.state_details.details.confirmed));
                            live.recovered = FormatNumber(Convert.ToInt32(userinput_statenamesandcode.state_details.details.recovered));
                            live.deceased = FormatNumber(Convert.ToInt32(userinput_statenamesandcode.state_details.details.deaths));
                            live.lastupdatedtime = userinput_statenamesandcode.state_details.details.lastupdatedtime;
                        }
                        if (live_vaccinated_cases.Count > 0)
                        {
                            live.vaccinated = FormatNumber(Convert.ToInt32(vaccinated.Last()));
                        }
                        if (live_tested_cases != null && live_date_cases != null && live_cases_results != null)
                        {
                            chart.tested = tested;
                            chart.vaccinated = vaccinated;
                            chart.confirmed = totalconfirmed;
                            chart.deceased = totaldeceased;
                            chart.recovered = totalrecovered;
                            chart.tested_dates = dates_tested;
                            chart.dates = dates_data;
                        }
                        if (live != null)
                        {
                            covid.live = live;
                            covid.chart = chart;
                            //covid.csv = csv_testing;
                        }
                        IEnumerable<SelectListItem> items = state_names_codes.Select(c => new SelectListItem
                        {
                            Value = c.details.state,
                            Text = c.details.state

                        }).OrderBy(x => x.Value);
                        ViewBag.JobTitle = items;
                        this.telemetry.InstrumentationKey = GetInstrumentationKey();
                        this.telemetry.TrackEvent("Covid-19 Info Page Loaded Successfully");
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        data = null;

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        this.telemetry.InstrumentationKey = GetInstrumentationKey();
                        this.telemetry.TrackEvent("Covid-19 Info Page Failed");
                        return View("ErrorPage");
                    }
                }

                return View("Index", covid);
            }
            catch (Exception ex)
            {
                this.telemetry.InstrumentationKey = GetInstrumentationKey();
                this.telemetry.TrackEvent("Covid-19 Info Page Failed");
                return View("ErrorPage");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromBody] UserData userdata)
        {
            IndiaStateDistrictWise.Rootobject data = null;
            try
            {
                if (!userdata.userinputerror)
                {
                    //var DailyCovidStatus = await GetDailyCovidStatus();

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(URL);
                        //HTTP GET
                        HttpResponseMessage responseTask = client.GetAsync(IndiaCovidStatus).Result;

                        if (responseTask.IsSuccessStatusCode)
                        {
                            var customerJsonString = await responseTask.Content.ReadAsStringAsync();
                            var dataObjects = JsonConvert.DeserializeObject<IndiaStateDistrictWise.Rootobject>(customerJsonString);
                            data = dataObjects;
                            client.Dispose();
                            covid.IndiaStateDistrictWise = data;
                            //covid.DailyCovidStatus = DailyCovidStatus;

                            var tested_results = (from testedresult in covid.IndiaStateDistrictWise.tested.Select((testeddetails) => new { testeddetails })
                                                  select new
                                                  {
                                                      details = testedresult.testeddetails,
                                                      tested_date = testedresult.testeddetails.updatetimestamp,
                                                      live_tested_numbers = testedresult.testeddetails.totalsamplestested,
                                                      live_vaccinated_numbers = testedresult.testeddetails.totaldosesadministered
                                                  }).Distinct().ToList();

                            var live_cases_results = (from liveresult in covid.IndiaStateDistrictWise.cases_time_series.Select((livedetails) => new { livedetails })
                                                      select new
                                                      {
                                                          details = liveresult.livedetails,
                                                          livedetails_confirmed = liveresult.livedetails.totalconfirmed,
                                                          livedetails_deceased = liveresult.livedetails.totaldeceased,
                                                          livedetails_recovered = liveresult.livedetails.totalrecovered,
                                                          livedetails_date = liveresult.livedetails.date
                                                      }).Distinct().ToList();

                            //var live_tested_cases = (from testedresultnumbers in tested_results.Select((testeddetailsnumbers) => new { testeddetailsnumbers })
                            //                         select new
                            //                         {
                            //                             tested_numbers = testedresultnumbers.testeddetailsnumbers.live_tested_numbers,
                            //                             tested_date = testedresultnumbers.testeddetailsnumbers.tested_date
                            //                         }).Distinct().ToDictionary(mc => mc.tested_date.ToString(),
                            //                                     mc => mc.tested_numbers.ToString(),
                            //                                     StringComparer.OrdinalIgnoreCase);

                            List<int> totalconfirmed = new List<int>();
                            foreach (var confirm in live_cases_results.TakeLast(7))
                            {
                                if (confirm.livedetails_confirmed != string.Empty)
                                    totalconfirmed.Add(Int32.Parse(confirm.livedetails_confirmed));
                            }

                            List<int> totaldeceased = new List<int>();
                            foreach (var deceased in live_cases_results.TakeLast(7))
                            {
                                if (deceased.livedetails_deceased != string.Empty)
                                    totaldeceased.Add(Int32.Parse(deceased.livedetails_deceased));
                            }

                            List<int> totalrecovered = new List<int>();
                            foreach (var recovered in live_cases_results.TakeLast(7))
                            {
                                if (recovered.livedetails_recovered != string.Empty)
                                    totalrecovered.Add(Int32.Parse(recovered.livedetails_recovered));
                            }

                            List<string> dates_data = new List<string>();
                            foreach (var date in live_cases_results.TakeLast(7))
                            {
                                if (date.livedetails_date != string.Empty)
                                {
                                    string MyString = date.livedetails_date;
                                    string removed_date = string.Empty;
                                    var dateformat = MyString.ToCharArray();

                                    if (dateformat[1] == ' ')
                                    {
                                        removed_date = MyString.Length <= 3 ? MyString : MyString.Substring(0, 5);
                                    }
                                    else
                                    {
                                        removed_date = MyString.Length <= 3 ? MyString : MyString.Substring(0, 6);
                                    }

                                    dates_data.Add(removed_date);
                                }

                            }

                            var live_vaccinated_cases = (from testedresultnumbers in tested_results.Select((testeddetailsnumbers) => new { testeddetailsnumbers }).Where(c => c.testeddetailsnumbers.live_vaccinated_numbers != null)
                                                         select new
                                                         {
                                                             vaccinated_numbers = testedresultnumbers.testeddetailsnumbers.live_vaccinated_numbers
                                                         }).Distinct().ToList();

                            List<int> vaccinated = new List<int>();
                            foreach (var vaccine in live_vaccinated_cases.TakeLast(7))
                            {
                                if (vaccine.vaccinated_numbers != string.Empty)
                                    vaccinated.Add(Int32.Parse(vaccine.vaccinated_numbers));
                            }

                            var live_tested_cases = (from testedresultnumbers in tested_results.Select((testeddetailsnumbers) => new { testeddetailsnumbers }).Where(c => c.testeddetailsnumbers.live_tested_numbers != null)
                                                     select new
                                                     {
                                                         tested_numbers = testedresultnumbers.testeddetailsnumbers.live_tested_numbers
                                                     }).Distinct().ToList();

                            List<int> tested = new List<int>();
                            foreach (var test in live_tested_cases.TakeLast(7))
                            {
                                if (test.tested_numbers != string.Empty)
                                    tested.Add(Int32.Parse(test.tested_numbers));
                            }

                            var live_date_cases = (from testedresultnumbers in tested_results.Select((testeddetailsnumbers) => new { testeddetailsnumbers })
                                                   select new
                                                   {
                                                       tested_date = testedresultnumbers.testeddetailsnumbers.tested_date
                                                   }).Distinct().ToList();

                            List<string> dates_tested = new List<string>();
                            foreach (var date in live_date_cases.TakeLast(7))
                            {
                                if (date.tested_date != string.Empty)
                                {
                                    string MyString = date.tested_date;
                                    string removed_date = MyString.Remove(10, 9);
                                    string[] correct_dataformat = removed_date.Split('/');
                                    int year = Convert.ToInt32(correct_dataformat[2]);
                                    int month = Convert.ToInt32(correct_dataformat[1]);
                                    int day = Convert.ToInt32(correct_dataformat[0]);
                                    DateTime dob = new DateTime(year, month, day);
                                    string date_dob = dob.ToString("D");
                                    string date_value = date_dob.Length <= 3 ? date_dob : date_dob.Substring(0, 6);
                                    dates_tested.Add(date_value);
                                }

                            }

                            //var covidstatus_perdate = covid.DailyCovidStatus.states_daily.Where(r => r.date == userdata.datetime).ToList();

                            var state_names_codes = (from result in covid.IndiaStateDistrictWise.statewise.Select((statedetails) => new { statedetails })
                                                     select new
                                                     {
                                                         details = result.statedetails,
                                                         code = result.statedetails.statecode
                                                     }).Distinct().ToList();

                            var total_statenamesandcode = (from r in state_names_codes.Where(r => r.code.Equals("TT"))
                                                           select new
                                                           {
                                                               state_details = r,
                                                               state_code = r.code.ToLower()
                                                           }).FirstOrDefault();

                            if (total_statenamesandcode != null)
                            {
                                live.active = FormatNumber(Convert.ToInt32(total_statenamesandcode.state_details.details.active));
                                live.confirmed = FormatNumber(Convert.ToInt32(total_statenamesandcode.state_details.details.confirmed));
                                live.recovered = FormatNumber(Convert.ToInt32(total_statenamesandcode.state_details.details.recovered));
                                live.deceased = FormatNumber(Convert.ToInt32(total_statenamesandcode.state_details.details.deaths));
                                live.lastupdatedtime = total_statenamesandcode.state_details.details.lastupdatedtime;
                            }
                            if (live_vaccinated_cases.Count > 0)
                            {
                                live.vaccinated = FormatNumber(Convert.ToInt32(vaccinated.Last()));
                            }
                            if (live_tested_cases != null && live_date_cases != null && live_cases_results != null)
                            {
                                chart.tested = tested;
                                chart.vaccinated = vaccinated;
                                chart.confirmed = totalconfirmed;
                                chart.deceased = totaldeceased;
                                chart.recovered = totalrecovered;
                                chart.tested_dates = dates_tested;
                                chart.dates = dates_data;
                            }
                            if (live != null)
                            {
                                covid.live = live;
                                covid.chart = chart;
                            }

                            var userinput_statenamesandcode = (from r in state_names_codes.Where(r => r.details.state.Equals(userdata.statename))
                                                               select new
                                                               {
                                                                   state_details = r,
                                                                   state_code = r.code.ToLower()
                                                               }).FirstOrDefault();

                            string beds_Availability = await GetStateWiseURLForBedsAvailability(userdata.statename);
                            if (!String.IsNullOrEmpty(beds_Availability))
                            {
                                covid.bedsAvailability = new BedsAvailability();
                                covid.bedsAvailability.URL = beds_Availability;
                            }
                            if (userinput_statenamesandcode != null)
                            {
                                
                                var dailyCovidDetails = await GetDailyCovidStatusLatest(userinput_statenamesandcode.state_code, userdata.datetime);
                                covidTrackerModel.Confirmed = FormatNumber(dailyCovidDetails.Item1[0]);
                                covidTrackerModel.Recovered = FormatNumber(dailyCovidDetails.Item1[1]);
                                covidTrackerModel.Deceased = FormatNumber(dailyCovidDetails.Item1[2]);
                                covidTrackerModel.Tested = FormatNumber(dailyCovidDetails.Item1[3]);
                                covidTrackerModel.Vaccinated1 = dailyCovidDetails.Item1[4];
                                covidTrackerModel.Vaccinated2 = dailyCovidDetails.Item1[5];
                                int TotalVaccinated = covidTrackerModel.Vaccinated1 + covidTrackerModel.Vaccinated2;
                                covidTrackerModel.AdminVaccinated = FormatNumber(TotalVaccinated);
                                if (!String.IsNullOrEmpty(dailyCovidDetails.Item2))
                                {
                                    covid.statewiseTotalVaccination = FormatNumber(Convert.ToInt32(dailyCovidDetails.Item2));
                                }
                                //var confirmed = covidstatus_perdate[0];
                                //covidTrackerModel.Confirmed = Convert.ToInt32(confirmed.GetType().GetProperty(userinput_statenamesandcode.state_code).GetValue(confirmed, null));
                                //var recovered = covidstatus_perdate[1];
                                //covidTrackerModel.Recovered = Convert.ToInt32(recovered.GetType().GetProperty(userinput_statenamesandcode.state_code).GetValue(recovered, null));
                                //var decreased = covidstatus_perdate[2];
                                //covidTrackerModel.Deceased = Convert.ToInt32(decreased.GetType().GetProperty(userinput_statenamesandcode.state_code).GetValue(decreased, null));
                                if (vaccinated.Count > 0)
                                {
                                    covidTrackerModel.Vaccinated = FormatNumber(Convert.ToInt32(vaccinated.Last()));
                                }
                                covid.statewisedetails = userinput_statenamesandcode.state_details.details;
                                covid.statewisedetails.active = FormatNumber(Convert.ToInt32(userinput_statenamesandcode.state_details.details.active));
                                covid.statewisedetails.confirmed = FormatNumber(Convert.ToInt32(userinput_statenamesandcode.state_details.details.confirmed));
                                covid.statewisedetails.deaths = FormatNumber(Convert.ToInt32(userinput_statenamesandcode.state_details.details.deaths));
                                covid.statewisedetails.recovered = FormatNumber(Convert.ToInt32(userinput_statenamesandcode.state_details.details.recovered));
                            }
                            if (covidTrackerModel != null && userdata != null)
                            {
                                covid.covidtracker = covidTrackerModel;
                                userdatadetails = userdata;
                                covid.UserData = userdatadetails;
                                ViewData["ApiDataFailedResult"] = true;
                            }

                            IEnumerable<SelectListItem> items = state_names_codes.Select(c => new SelectListItem
                            {
                                Value = c.details.state,
                                Text = c.details.state

                            }).OrderBy(x => x.Value);

                            ViewBag.JobTitle = items;
                            this.telemetry.InstrumentationKey = GetInstrumentationKey();
                            this.telemetry.TrackEvent("Covid-19 Info Page Loaded Successfully in POST method");
                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            data = null;

                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                            this.telemetry.InstrumentationKey = GetInstrumentationKey();
                            this.telemetry.TrackEvent("Covid-19 Info Page Failed in POST method");
                            return View("ErrorPage");
                        }
                    }
                }

                return View("Index", covid);
            }
            catch (Exception ex)
            {
                data = null;
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                this.telemetry.InstrumentationKey = GetInstrumentationKey();
                this.telemetry.TrackEvent("Covid-19 Info Page Failed in POST method");
                return View("ErrorPage");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Weather()
        {
            Location_Weather.Weather data = null;
            try
            {
                DateTime aDate = DateTime.Now;
                ViewModel mymodel = new ViewModel();
                var validipaddress = await GetValidIpaddress();
                var ipaddress = await GetIpaddress();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WeatherURL);
                    //HTTP GET
                    HttpResponseMessage responseTask = client.GetAsync(Weather_ForCurrentLocation + validipaddress.city).Result;

                    if (responseTask.IsSuccessStatusCode)
                    {
                        var customerJsonString = await responseTask.Content.ReadAsStringAsync();
                        var dataObjects = JsonConvert.DeserializeObject<Location_Weather.Weather>(customerJsonString);
                        //JObject obj = JObject.Parse(customerJsonString);
                        //var forecast_details = obj.SelectToken("forecast").Children().OfType<JProperty>()
                        //            .ToDictionary(p => p.Name, p => new
                        //            {
                        //                MaxTemp = (int)p.First()["maxtemp"],
                        //                MinTemp = (int)p.First()["mintemp"]
                        //            });
                        //if (forecast_details.Count > 0)
                        //{
                        //    int max_temp = forecast_details.Values.Select(x => x.MaxTemp).FirstOrDefault();
                        //    int min_temp = forecast_details.Values.Select(x => x.MinTemp).FirstOrDefault();
                        //    //mymodel.maxtemp = max_temp;
                        //    //mymodel.mintemp = min_temp;
                        //}

                        data = dataObjects;
                        client.Dispose();
                        if (ipaddress != null && data != null && validipaddress != null)
                        {
                            mymodel.IPAddress = ipaddress;
                            mymodel.ValidIPAddress = validipaddress;
                            mymodel.Weather = data;
                            this.telemetry.InstrumentationKey = GetInstrumentationKey();
                            this.telemetry.TrackEvent("Weather Info Page Loaded Successfully");
                        }
                        else
                        {
                            data = null;

                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                            this.telemetry.InstrumentationKey = GetInstrumentationKey();
                            this.telemetry.TrackEvent("Weather Info Page Failed");
                            return View("ErrorPage");
                        }

                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        data = null;

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        this.telemetry.InstrumentationKey = GetInstrumentationKey();
                        this.telemetry.TrackEvent("Weather Info Page Failed");
                        return View("ErrorPage");
                    }
                }

                return View("Weather", mymodel);
            }
            catch (Exception ex)
            {
                data = null;

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                this.telemetry.InstrumentationKey = GetInstrumentationKey();
                this.telemetry.TrackEvent("Weather Info Page Failed");
                return View("ErrorPage");
            }

        }

        [HttpGet]
        public ActionResult LandingPage()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult GetMaps(string lat, string lon)
        {
            ViewModel mymodel = new ViewModel();
            mymodel.MapLocation = new MapLocation();
            mymodel.MapLocation.Lat = lat;
            mymodel.MapLocation.Lon = lon;
            this.telemetry.InstrumentationKey = GetInstrumentationKey();
            this.telemetry.TrackEvent("Maps Page Loaded Successfully");
            return View("Maps", mymodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Maps(string s)
        {
            var result = s.Split('-');
            ViewModel mymodel = new ViewModel();
            mymodel.MapLocation = new MapLocation();
            mymodel.MapLocation.Lat = result[1];
            mymodel.MapLocation.Lon = result[3];
            return Json(new { success = true, url = Url.Action("GetMaps", "Home", new { lat = mymodel.MapLocation.Lat, lon = mymodel.MapLocation.Lon }) });
        }

        [HttpGet]
        public async Task<IActionResult> Vaccine()
        {
            try
            {
                covid.vaccineCenterByPin = vaccineCenterByPin;
                this.telemetry.InstrumentationKey = GetInstrumentationKey();
                this.telemetry.TrackEvent("Vaccine Info Page Loaded Successfully - Get Method");
                return View("VaccineCenterByPin", covid);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                this.telemetry.InstrumentationKey = GetInstrumentationKey();
                this.telemetry.TrackEvent("Vaccine Info Page Failed- Get method");
                return View("ErrorPage");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Vaccine(string pincode, string date, bool nextweek, bool prevweek)
        {
            try
            {
                VaccineCenterByPin data = null;
                List<string> old_vaccinedates = new List<string>();

                CultureInfo provider = CultureInfo.InvariantCulture;
                if (!date.Contains("-") && nextweek)
                {
                    var inputDate = DateTime.ParseExact(date, "dd MMMM yyyy", provider);
                    //Added 1 date forward
                    var requiredDate = inputDate.AddDays(1).ToString("dd-MM-yyyy");
                    data = await GetVaccineByPin(pincode, requiredDate);
                    old_vaccinedates = NextWeekDates(requiredDate);
                }
                else if (!date.Contains("-") && prevweek)
                {
                    var inputDate = DateTime.ParseExact(date, "dd MMMM yyyy", provider);
                    //Added 7 dates backward
                    var requiredDate = inputDate.AddDays(-7).ToString("dd-MM-yyyy");
                    data = await GetVaccineByPin(pincode, requiredDate);
                    old_vaccinedates = NextWeekDates(requiredDate);
                }
                else
                {
                    data = await GetVaccineByPin(pincode, date);
                    old_vaccinedates = NextWeekDates(date);
                }

                List<string> addressForUI = new List<string>();
                string address = string.Empty;
                List<string> sessionsForUI = new List<string>();
                string sessionsFor18 = string.Empty;
                string sessionsFor45 = string.Empty;

                List<VaccineCenterByPin.Session> latestSessionFor18 = new List<VaccineCenterByPin.Session>();
                List<VaccineCenterByPin.Session> latestSessionFor45 = new List<VaccineCenterByPin.Session>();
                List<KeyValuePair<string, string>> sessionsByDate = new List<KeyValuePair<string, string>>();
                
                if (data != null)
                {
                    foreach (var vaccine_result in data.centers)
                    {
                        vaccine_result.from = TimingToAMandPM(vaccine_result.from);
                        vaccine_result.to = TimingToAMandPM(vaccine_result.to);
                        address = vaccine_result.name + "\n" + vaccine_result.address + "\n" + vaccine_result.state_name + ", " + vaccine_result.pincode + "\n" + "Timings: " + vaccine_result.from + " - " + vaccine_result.to + "\n" + "Type: " + vaccine_result.fee_type;
                        //addressForUI.Add(address);
                        List<KeyValuePair<string, VaccineCenterByPin.Session>> listOfSessionsByDate = new List<KeyValuePair<string, VaccineCenterByPin.Session>>();
                        Dictionary<string, VaccineCenterByPin.Session> dict = new Dictionary<string, VaccineCenterByPin.Session>();
                        foreach (var vaccine_result_sessions in vaccine_result.sessions)
                        {
                            var dates = DateTime.ParseExact(vaccine_result_sessions.date, "dd-MM-yyyy", provider);
                            var rishi_result = dates.ToString("dd MMMM yyyy");
                            vaccine_result_sessions.date = rishi_result;
                            
                            if (vaccine_result_sessions.min_age_limit == 18)
                            {
                                sessionsFor18 = vaccine_result_sessions.available_capacity + "\n" + vaccine_result_sessions.available_capacity_dose1 + "\n" + vaccine_result_sessions.available_capacity_dose2 + "\n" + vaccine_result_sessions.vaccine + "\n" + vaccine_result_sessions.min_age_limit;
                                vaccine_result_sessions.allDetails = sessionsFor18;                               
                                List<bool> result_date = new List<bool>();
                                foreach (var ready in old_vaccinedates)
                                {
                                    result_date.Add(vaccine_result_sessions.date.Equals(ready));
                                    if (vaccine_result_sessions.date.Equals(ready))
                                    {
                                        vaccine_result_sessions.vaccineAvailableDisplay = "Available";
                                        vaccine_result_sessions.vaccineAvailableForMultipleAgesDisplay = true;

                                    }
                                }

                                dict.Add(vaccine_result_sessions.date + "-" + "18" + "-" + vaccine_result_sessions.vaccine, vaccine_result_sessions);
                                latestSessionFor18.Add(vaccine_result_sessions);
                            }
                            else
                            {
                                sessionsFor45 = vaccine_result_sessions.available_capacity + "\n" + vaccine_result_sessions.available_capacity_dose1 + "\n" + vaccine_result_sessions.available_capacity_dose2 + "\n" + vaccine_result_sessions.vaccine + "\n" + vaccine_result_sessions.min_age_limit;
                                sessionsByDate.Add(new KeyValuePair<string, string>(vaccine_result_sessions.date, sessionsFor45));
                                vaccine_result_sessions.allDetails = sessionsFor45;                                
                                List<bool> result_date = new List<bool>();
                                foreach (var ready in old_vaccinedates)
                                {
                                    result_date.Add(vaccine_result_sessions.date.Equals(ready));
                                    if (vaccine_result_sessions.date.Equals(ready))
                                    {
                                        vaccine_result_sessions.vaccineAvailableDisplay = "Available";
                                        vaccine_result_sessions.vaccineAvailableForMultipleAgesDisplay = false;
                                    }
                                }
                                latestSessionFor45.Add(vaccine_result_sessions);
                                dict.Add(vaccine_result_sessions.date + "-" + "45" + "-" + vaccine_result_sessions.vaccine, vaccine_result_sessions);
                            }

                            listOfSessionsByDate.Add(new KeyValuePair<string, VaccineCenterByPin.Session>(vaccine_result_sessions.date, vaccine_result_sessions));                                             
                        }
                        if (vaccine_result.sessions.Count() < 15 && dict.Count > 0 && (latestSessionFor18.Count > 0 || latestSessionFor45.Count > 0))
                        {
                            if (listOfSessionsByDate.Count > 0)
                            {
                                List<string> allKeys = (from kvp in listOfSessionsByDate select kvp.Key).Distinct().ToList();
                                var keys = allKeys.OrderBy(x => DateTime.ParseExact(x, "dd MMMM yyyy", CultureInfo.InvariantCulture)).ToList();
                                var missedDaysInSessions = old_vaccinedates.Except(allKeys).ToList();
                                missedDaysInSessions.Sort();
                                
                                Dictionary<string, VaccineCenterByPin.Session> dict2 = new Dictionary<string, VaccineCenterByPin.Session>();
                                Dictionary<string, List<VaccineCenterByPin.Session>> resultdict = new Dictionary<string, List<VaccineCenterByPin.Session>>();
                                foreach (var result in missedDaysInSessions)
                                {                                    
                                    dict2.Add(result, new VaccineCenterByPin.Session { date = result, vaccineAvailableDisplay = "NotAvailable" });
                                    
                                }                                
                                dict2.ToList().ForEach(x => dict.Add(x.Key, x.Value));// Merge two Dictionary                                
                                var dictValues = (from d in dict select d.Value).Distinct().ToList();                                
                                
                                foreach (var resultDate in old_vaccinedates)
                                {
                                    var resultDictValues = dictValues.Where(x => x.date.Equals(resultDate)).ToList();
                                    resultdict.Add(resultDate, resultDictValues);
                                }

                                vaccine_result.displaySessionsOnUI = resultdict;
                            }                            
                        }
                    }
                }
                else
                {
                    this.telemetry.InstrumentationKey = GetInstrumentationKey();
                    this.telemetry.TrackEvent("Cowin Vaccine API returned null - Post Method");
                    return Json(new { success = false, vaccineDataEmpty = true, addressForUI, sessionsForUI, old_vaccinedates });
                }

                VaccineCenterByPin vaccine = new VaccineCenterByPin();
                vaccine = data;

                var vaccineAddressDetails = vaccine.centers.OrderBy(x => x.name).Distinct().ToList();

                foreach(var resultAddress in vaccineAddressDetails)
                {
                    string addressDetails = resultAddress.name + "\n" + resultAddress.address + "\n" + resultAddress.state_name + ", " + resultAddress.pincode + "\n" + "Timings: " + resultAddress.from + " - " + resultAddress.to + "\n" + "Type: " + resultAddress.fee_type + "\n";
                    if (resultAddress.vaccine_fees != null) {
                        foreach (var fees in resultAddress.vaccine_fees)
                        {
                            addressDetails += "\n" + "<u>" + $"{fees.vaccine}: Rs." + fees.fee + "</u>";
                        }
                    }
                    
                    addressForUI.Add(addressDetails);
                }

                this.telemetry.InstrumentationKey = GetInstrumentationKey();
                this.telemetry.TrackEvent("Vaccine Info Page Loaded Successfully - Post Method");
                if (addressForUI.Count == 0 && sessionsForUI.Count == 0)
                {
                    return Json(new { success = false, vaccine, addressForUI, sessionsForUI, old_vaccinedates });
                }
                else
                {                    
                    var vaccineDetails = vaccine.centers.OrderBy(x => x.name).Distinct().ToList();
                    return Json(new { success = true, vaccine, addressForUI, sessionsForUI, old_vaccinedates, sessionsByDate, vaccineDetails });
                }

            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                this.telemetry.InstrumentationKey = GetInstrumentationKey();
                this.telemetry.TrackEvent("Vaccine Info Page Failed- Post method");
                return View("ErrorPage");
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> BirthdayMain(string date)
        //{
        //    this.telemetry.InstrumentationKey = GetInstrumentationKey();
        //    this.telemetry.TrackEvent("Birthday Page Loaded Successfully.");
        //    return View("BirthdayMain");
        //}

        private async Task<VaccineCenterByPin> GetVaccineByPin(string pincode, string date)
        {
            var cts = new CancellationTokenSource();
            bool retry = true;
            try
            {
                VaccineCenterByPin data = null;

                //var client = new RestClient(VaccineCenterByPin + "?" + "pincode=" + pincode + "&" + "date=" + date);
                //client.Timeout = -1;
                //var request = new RestRequest(VaccineCenterByPin + "?" + "pincode=" + pincode + "&" + "date=" + date,Method.GET,DataFormat.Json);
                //request.ReadWriteTimeout = 4000;
                //IRestResponse response = client.Execute(request);
                //if (response.IsSuccessful)
                //{                
                //    var dataObjects = JsonConvert.DeserializeObject<VaccineCenterByPin>(response.Content);
                //    data = dataObjects;

                //}
                //else //web api sent error response 
                //{
                //    //log response status here..
                //    data = null;
                //}

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(4);
                    client.BaseAddress = new Uri(VaccineCenterByPin);
                    //HTTP GET
                    HttpResponseMessage responseTask = client.GetAsync(VaccineCenterByPin + "?" + "pincode=" + pincode + "&" + "date=" + date, cts.Token).Result;
                    if (responseTask.IsSuccessStatusCode)
                    {
                        var customerJsonString = await responseTask.Content.ReadAsStringAsync();
                        var dataObjects = JsonConvert.DeserializeObject<VaccineCenterByPin>(customerJsonString);
                        data = dataObjects;
                    }
                    else //web api sent error response 
                    {
                        Thread.Sleep(4000);
                        HttpResponseMessage responseTaskForRetry = null;
                        if (retry)
                        {
                            responseTaskForRetry = client.GetAsync(VaccineCenterByPin + "?" + "pincode=" + pincode + "&" + "date=" + date, cts.Token).Result;
                            if (responseTaskForRetry.IsSuccessStatusCode)
                            {
                                var customerJsonStringForRetry = await responseTask.Content.ReadAsStringAsync();
                                var dataObjectsForRetry = JsonConvert.DeserializeObject<VaccineCenterByPin>(customerJsonStringForRetry);
                                data = dataObjectsForRetry;
                                retry = false;
                            }
                        }
                        if (!responseTaskForRetry.IsSuccessStatusCode && !responseTask.IsSuccessStatusCode)
                        {
                            //log response status here..
                            this.telemetry.InstrumentationKey = GetInstrumentationKey();
                            this.telemetry.TrackEvent($"In vaccine API Request Not Success call block Reason-Phrase: {responseTaskForRetry.ReasonPhrase} and Status: {responseTaskForRetry.StatusCode}");
                            Thread.Sleep(3000);
                            data = null;
                        }
                    }
                    client.Dispose();
                }

                return data;
            }
            catch (WebException ex)
            {
                this.telemetry.InstrumentationKey = GetInstrumentationKey();
                this.telemetry.TrackEvent($"In vaccine API Request WebException.");
                return null;
            }
            catch (TaskCanceledException ex)
            {
                if (ex.CancellationToken == cts.Token)
                {
                    this.telemetry.InstrumentationKey = GetInstrumentationKey();
                    this.telemetry.TrackEvent($"In vaccine API Request where TaskCanceledException.CancellationToken and generated token are same.");
                    return null;
                }
                else
                {
                    this.telemetry.InstrumentationKey = GetInstrumentationKey();
                    this.telemetry.TrackEvent($"In vaccine API Request TaskCanceledException.");
                    return null;
                }
            }
        }

        private async Task<Location_Weather.ClientIPAddress> GetIpaddress()
        {
            //string clientIPAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var ip = /*"27.59.201.51";*/ _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();//Gives you client IPAddress
            Location_Weather.ClientIPAddress data = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IPAddressURL);
                //HTTP GET
                HttpResponseMessage responseTask = client.GetAsync(ip + IPAddress_AccessKey).Result;

                if (responseTask.IsSuccessStatusCode)
                {
                    var customerJsonString = await responseTask.Content.ReadAsStringAsync();
                    var dataObjects = JsonConvert.DeserializeObject<Location_Weather.ClientIPAddress>(customerJsonString);
                    data = dataObjects;
                    client.Dispose();
                }
                else //web api sent error response 
                {
                    //log response status here..
                    data = null;
                }
            }
            return data;
        }


        private async Task<Location_Weather.ValidIPAddress> GetValidIpaddress()
        {
            var ip = /*"27.59.201.51";*/ _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();//Gives you client IPAddress
            Location_Weather.ValidIPAddress data = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ValidIPAddressURL + ip);
                //HTTP GET
                HttpResponseMessage responseTask = client.GetAsync(string.Empty).Result;

                if (responseTask.IsSuccessStatusCode)
                {
                    var customerJsonString = await responseTask.Content.ReadAsStringAsync();
                    var dataObjects = JsonConvert.DeserializeObject<Location_Weather.ValidIPAddress>(customerJsonString);
                    data = dataObjects;
                    client.Dispose();
                }
                else //web api sent error response 
                {
                    //log response status here..
                    data = null;
                }
            }
            return data;
        }

        private async Task<StateWiseDailyCovidCasesData> GetDailyCovidStatus()
        {

            StateWiseDailyCovidCasesData data = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(DailyCovidStatus);
                //HTTP GET
                HttpResponseMessage responseTask = client.GetAsync(DailyCovidStatus).Result;

                if (responseTask.IsSuccessStatusCode)
                {
                    var customerJsonString = await responseTask.Content.ReadAsStringAsync();
                    //var date = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    //var dailyDetails = await DailyCovidCases(customerJsonString, statecode, date);
                    var dataObjects = JsonConvert.DeserializeObject<StateWiseDailyCovidCasesData>(customerJsonString);
                    data = dataObjects;
                    client.Dispose();
                }
                else //web api sent error response 
                {
                    //log response status here..
                    data = null;
                }
            }
            return data;
        }

        private async Task<Tuple<List<int>, string>> GetDailyCovidStatusLatest(string statecode,string date)
        {
            Tuple<List<int>, string> data = null;
            string statewiseVaccinatedPeople = "";
            CultureInfo provider = CultureInfo.InvariantCulture;
            var userdate = DateTime.ParseExact(date, "dd-MMM-yy", provider);
            var userInputedDate = userdate.ToString("yyyy-MM-dd");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(DailyCovidStatus);
                //HTTP GET
                HttpResponseMessage responseTask = client.GetAsync(DailyCovidStatus).Result;

                if (responseTask.IsSuccessStatusCode)
                {
                    var customerJsonString = await responseTask.Content.ReadAsStringAsync();
                    //var date = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    var dailyDetails = DailyCovidCases(customerJsonString, statecode, userInputedDate, out statewiseVaccinatedPeople);
                    if (dailyDetails.Count > 0)
                    {
                        var covidDetails_raw = dailyDetails.Select(x => x.Split(":"));
                        List<int> covidDetails = new List<int>();
                        var confirmed = covidDetails_raw.SelectMany(x => x.Where(r => r.Contains("confirmed")).Select(item => new { Confirmed = x[1] })).ToList();
                        var recovered = covidDetails_raw.SelectMany(x => x.Where(r => r.Contains("recovered")).Select(item => new { Recovered = x[1] })).ToList();
                        var deceased = covidDetails_raw.SelectMany(x => x.Where(r => r.Contains("deceased")).Select(item => new { Deceased = x[1] })).ToList();
                        var tested = covidDetails_raw.SelectMany(x => x.Where(r => r.Contains("tested")).Select(item => new { Tested = x[1] })).ToList();
                        var vaccinated1 = covidDetails_raw.SelectMany(x => x.Where(r => r.Contains("vaccinated1")).Select(item => new { Vaccinated1 = x[1] })).ToList();
                        var vaccinated2 = covidDetails_raw.SelectMany(x => x.Where(r => r.Contains("vaccinated2")).Select(item => new { Vaccinated2 = x[1] })).ToList();
                        covidDetails.Add(Int32.Parse(confirmed[0].Confirmed));
                        covidDetails.Add(Int32.Parse(recovered[0].Recovered));
                        covidDetails.Add(Int32.Parse(deceased[0].Deceased));
                        covidDetails.Add(Int32.Parse(tested[0].Tested));
                        covidDetails.Add(Int32.Parse(vaccinated1[0].Vaccinated1));
                        covidDetails.Add(Int32.Parse(vaccinated2[0].Vaccinated2));
                        if (!String.IsNullOrEmpty(statewiseVaccinatedPeople))
                        {
                            data = new Tuple<List<int>, string>(covidDetails, statewiseVaccinatedPeople);
                        }
                        else
                        {
                            data = new Tuple<List<int>, string>(covidDetails, null);
                        }

                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(statewiseVaccinatedPeople))
                        {
                            data = new Tuple<List<int>, string>(null, statewiseVaccinatedPeople);
                        }
                        else
                        {
                            data = new Tuple<List<int>, string>(null, null);
                        }
                    }



                    client.Dispose();
                }
                else //web api sent error response 
                {
                    //log response status here..
                    data = new Tuple<List<int>, string>(null, null);
                }
            }
            return data;
        }

        private string FormatNumber(int num)
        {
            int i = (int)Math.Pow(10, (int)Math.Max(0, Math.Log10(num) - 2));
            num = num / i * i;

            if (num >= 1000000000)
                return (num / 1000000000D).ToString("0.##") + "B";
            if (num >= 1000000)
                return (num / 1000000D).ToString("0.##") + "M";
            if (num >= 1000)
                return (num / 1000D).ToString("0.##") + "K";

            return num.ToString("#,0");
        }


        private List<string> DailyCovidCases(string customerJsonString, string statecode, string date, out string statewiseVaccinatedPeople)
        {
            List<string> result = new List<string>();
            statewiseVaccinatedPeople = "";
            JObject obj = JObject.Parse(customerJsonString);
            var forecast_details = obj.SelectToken(statecode.ToUpper()).Children().OfType<JProperty>().Select(x => x.Value)
                                   .Select(x => x.SelectToken(date)).SelectMany(x => x.SelectToken("delta")).ToList();
            if (forecast_details.Count > 0)
            {
                forecast_details.ForEach(x => result.Add(x.ToString()));
            }
            var forecast_details_vaccine = obj.SelectToken(statecode.ToUpper()).Children().OfType<JProperty>().Select(x => x.Value)
                                   .Select(x => x.SelectToken(date)).SelectMany(x => x.SelectToken("total")).ToList();

            if (forecast_details_vaccine.Count > 0)
            {
                var covidDetails_raw = forecast_details_vaccine.Select(x => x.ToString().Split(":"));

                var vaccinated1 = covidDetails_raw.SelectMany(x => x.Where(r => r.Contains("vaccinated1")).Select(item => new { Vaccinated1 = x[1] })).ToList();
                var vaccinated2 = covidDetails_raw.SelectMany(x => x.Where(r => r.Contains("vaccinated2")).Select(item => new { Vaccinated2 = x[1] })).ToList();

                int vaccine1 = Convert.ToInt32(vaccinated1[0].Vaccinated1);
                int vaccine2 = Convert.ToInt32(vaccinated2[0].Vaccinated2);
                statewiseVaccinatedPeople = (vaccine1 + vaccine2).ToString();
            }

            return result;
        }


        private string GetInstrumentationKey()
        {
            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay= TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(16),
                    MaxRetries = 5,
                    Mode = RetryMode.Exponential
                 }
            };

            var client = new SecretClient(new Uri("https://covid-19-wld-keys.vault.azure.net/"), new DefaultAzureCredential(), options);

            KeyVaultSecret secret = client.GetSecret("ApplicationInsights-InstrumentationKey");

            return secret.Value;
        }

        private async Task<string> GetStateWiseURLForBedsAvailability(string statename)
        {
            switch (statename)
            {
                case "Total":
                    return "https://docs.google.com/spreadsheets/d/130qcsFW3kkP8sf9rBKVdDonKOBE17F-CITWyR3PwEg4/edit#gid=1913344692";
                case "Andaman and Nicobar Islands":
                    return "Helpline numbers: 03192-232102, 234287, 09474280024";
                case "Andhra Pradesh":
                    return "http://dashboard.covid19.ap.gov.in/ims/hospbed_reports/";
                case "Arunachal Pradesh":
                    return "Helpline numbers: 0360-2214216/2214238 and +91 9485236624/9436055743";
                case "Assam":
                    return "https://covid19.assam.gov.in/";
                case "Bihar":
                    return "https://covid19.bihar.gov.in/";
                case "Chandigarh":
                    return "http://chandigarh.gov.in/health_covid19.htm";
                case "Chhattisgarh":
                    return "https://cg.nic.in/health/covid19/RTPBedAvailable.aspx";
                case "Dadra and Nagar Haveli and Daman and Diu":
                    return "https://covidfacility.dddgov.in/";
                case "Delhi":
                    return "https://coronabeds.jantasamvad.org/";
                case "Goa":
                    return "https://www.goa.gov.in/covid-19/goa-fights-covid-19/";
                case "Gujarat":
                    return "http://office.suratsmartcity.com/SuratCOVID19/";
                case "Haryana":
                    return "https://coronaharyana.in/";
                case "Himachal Pradesh":
                    return "http://www.nrhmhp.gov.in/content/covid-health-facilities";
                case "Jammu and Kashmir":
                    return "Helpline numbers: 01912520982, 0194-2440283";
                case "Jharkhand":
                    return "https://www.jharkhand.gov.in/Home/Covid19Dashboard";
                case "Karnataka":
                    return "https://bbmpgov.com/chbms/";
                case "Kerala":
                    return "https://covid19jagratha.kerala.nic.in/home/addHospitalDashBoard";
                case "Ladakh":
                    return "https://covid.ladakh.gov.in/";
                case "Lakshadweep":
                    return "https://lakshadweep.gov.in/past-notices/covid_19/";
                case "Madhya Pradesh":
                    return "http://sarthak.nhmmp.gov.in/covid/facility-bed-occupancy-dashboard/";
                case "Maharashtra":
                    return "https://nmmchealthfacilities.com/HospitalInfo/showhospitalist";
                case "Manipur":
                    return "Helpline numbers: 1800-3453-818, 3852411668";
                case "Meghalaya":
                    return "https://meghealth.in/MeghCare.html";
                case "Mizoram":
                    return "Helpline numbers: 0389-2323336/2322336/2318336";
                case "Nagaland":
                    return "Helpline numbers: 0370-227003";
                case "Odisha":
                    return "https://statedashboard.odisha.gov.in/";
                case "Puducherry":
                    return "https://covid19dashboard.py.gov.in/BedAvailabilityDetails";
                case "Punjab":
                    return "https://corona.punjab.gov.in/";
                case "Rajasthan":
                    return "https://covidinfo.rajasthan.gov.in/COVID19HOSPITALBEDSSTATUSSTATE.aspx";
                case "Sikkim":
                    return "https://www.covid19sikkim.org/";
                case "Tamil Nadu":
                    return "https://stopcorona.tn.gov.in/beds.php";
                case "Telangana":
                    return "http://164.100.112.24/SpringMVC/Hospital_Beds_Statistic_Bulletin_citizen.htm";
                case "Tripura":
                    return "Helpline numbers: 0381-2315879/2412424/2413434/2410111/2411622 and 8414-969-592";
                case "Uttar Pradesh":
                    return "https://beds.dgmhup-covid19.in/EN/covid19bedtrack";
                case "Uttarakhand":
                    return "https://covid19.uk.gov.in/bedssummary.aspx";
                case "West Bengal":
                    return "https://www.wbhealth.gov.in/";
            }
            return null;
        }

        private string TimingToAMandPM(string s)
        {
            string data = s;
            bool midnightflag = false;
            var number_to = data.Split(':');
            if (int.Parse(number_to[0]) > 12)
            {
                int hourformat = int.Parse(number_to[0]) - 12;
                if (hourformat == 12)
                {
                    midnightflag = true;
                }

                if (!midnightflag)
                {
                    string result_to = string.Concat(hourformat.ToString(), ":", number_to[1]);
                    if (data.EndsWith(":"))
                    {
                        data = data.Remove(4, 1) + " " + "PM";
                    }
                    data = result_to + " " + "PM";
                }
                else
                {
                    string result_to = string.Concat(hourformat.ToString(), ":", number_to[1]);
                    if (data.EndsWith(":"))
                    {
                        data = data.Remove(4, 1) + " " + "AM";
                    }
                    data = result_to + " " + "AM";
                }
            }
            else
            {
                string result = string.Concat(number_to[0], ":", number_to[1]);
                if (int.Parse(number_to[0]) == 12)
                {
                    data = result + " " + "PM";
                }
                else
                {
                    data = result + " " + "AM";
                }
            }
            return data;
        }

        private List<string> NextWeekDates(string date)
        {
            List<string> week = new List<string>();
            CultureInfo provider = CultureInfo.InvariantCulture;
            var dates = DateTime.ParseExact(date, "dd-MM-yyyy", provider);
            dates.ToString("dd MMMM yyyy");
            for (int i = 0; i < 7; i++)
            {
                week.Add(dates.AddDays(i).ToString("dd MMMM yyyy"));
            }
            return week;
        }
    }
}
