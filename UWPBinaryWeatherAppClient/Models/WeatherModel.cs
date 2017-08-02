using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPBinaryWeatherAppClient.Models
{
    public class WeatherModel
    {
        public string CityName { get; set; }
        public List<DailyForecast> Forecast { get; set; }
    }
}
