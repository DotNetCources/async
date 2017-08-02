using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPBinaryWeatherAppClient.Models
{
    public class DailyForecast
    {
        public double morning { get; set; }
        public double day { get; set; }
        public double evening { get; set; }
        public double night { get; set; }
        public bool rain { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
        public string icon { get; set; }
        public string date { get; set; }
    }
}
