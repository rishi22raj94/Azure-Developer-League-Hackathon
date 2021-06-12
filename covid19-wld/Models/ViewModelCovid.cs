using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using covid19_wld.Model.CovidStatus;
using covid19_wld.Models;

namespace covid19_wld.Model
{
    public class ViewModelCovid
    {
        public DailyCovidStatus DailyCovidStatus { get; set; }
        public IndiaStateDistrictWise.Rootobject IndiaStateDistrictWise { get; set; }
        public UserData UserData { get; set; }
        public IndiaStateDistrictWise.Statewise statewisedetails { get; set; }
        public CovidTracker covidtracker { get; set; }
        public LiveCases live { get; set; }
        public Chart chart { get; set; }
        public CSVTesting csv { get; set; }
        public BedsAvailability bedsAvailability { get; set; }
        public VaccineCenterByPin.Center vaccineCenterByPin { get; set; }

        public string statewiseTotalVaccination { get; set; }
    }
}
