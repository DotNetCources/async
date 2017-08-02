using BinaryWeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BinaryWeatherApp.Services
{
	public class WeatherService : IWeatherService
	{
		private string api = "03b4475836684e7572334999a38a5fbf";

		public async Task<Forecast> Get(string city, int days)
		{
			if (!string.IsNullOrWhiteSpace(city))
			{
				string url = $"http://api.openweathermap.org/data/2.5/forecast/daily?q={city}&cnt={days}&units=metric&APPID={api}";

                string response;

                using (WebClient client = new WebClient())
                {
                    response = await client.DownloadStringTaskAsync(url);
                }
                
				Forecast forecast = new Forecast(JsonConvert.DeserializeObject<RootObject>(response));

				return forecast;
			}
			else
			{
				return null;
			}
		}
	}
}