using BinaryWeatherApp.Models;
using BinaryWeatherApp.Repositories;
using BinaryWeatherApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BinaryWeatherApp.ApiControllers
{
	public class WeatherController : ApiController
	{
		//GET api/Weather/?city=cityName&days=numOfDays

		[HttpGet]
		public async Task<Forecast> Get(string city, int days)
		{
			WeatherService weatherservice = new WeatherService();
			var forecast = await  weatherservice.Get(city, days);
			if (forecast != null)
			{
				IUnitOfWork unitofwork = new UnitOfWork("WeatherContext");
				Request request = new Request
				{
					RequestTown = forecast.city,
					RequestDays = days,
					RequestDate = forecast.GetDailyList()[0].date,
					RequestImg = forecast.GetDailyList()[0].icon,
					RequestTemp = forecast.GetDailyList()[0].day
				};
				await unitofwork.Requests.CreateAsync(request);
			}
			return forecast;
		}
	}
}
