using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Model
{
    public class Weathers
    {
        public string success { get; set; }
        public Result result { get; set; }
        public string msg { get; set; }
    }

    public class CityInfo
    {
        public string city { get; set; }
        public string citykey { get; set; }
        public string parent { get; set; }
        public string updateTime { get; set; }
    }

    public class Forecast
    {
        public string date { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string ymd { get; set; }
        public string weed { get; set; }
        public string sunrise { get; set; }
        public string aqi { get; set; }
        public string fx { get; set; }
        public string fl { get; set; }
        public string type { get; set; }
        public string notice { get; set; }
    }

    public class Result
    {
        public string days { get; set; }
        public string week { get; set; }
        public string weather_curr { get; set; }
        public string temp_high { get; set; }
        public string temp_low { get; set; }
        public string citynm { get; set; }
    }
}
