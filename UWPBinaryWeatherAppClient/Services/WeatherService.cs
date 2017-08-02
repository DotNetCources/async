using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UWPBinaryWeatherAppClient.Models;

namespace UWPBinaryWeatherAppClient.Services
{
    public class WeatherService
    {
        private string apiPath;
        private HttpClient client;
        public WeatherService()
        {
            apiPath = "http://localhost:59524/api/";
            client = new HttpClient();
        }
        public async Task<WeatherModel> GetForecast(string city, int days)
        {
            var response = await client.GetAsync($"{apiPath}Weather/?city={city}&days={days}");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WeatherModel>(result);
        }
    }
}
