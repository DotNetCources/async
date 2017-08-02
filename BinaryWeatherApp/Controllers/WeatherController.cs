using BinaryWeatherApp.Models;
using BinaryWeatherApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using BinaryWeatherApp.Repositories;
using System.Threading.Tasks;

namespace BinaryWeatherApp.Controllers
{
	public class WeatherController : Controller
	{
		IWeatherService weatherService;
		IUnitOfWork unitOfWork;
		

		public WeatherController(IWeatherService iws, IUnitOfWork iuow)
		{
			weatherService = iws;
			unitOfWork = iuow;
           
		}
		public async Task<ActionResult> Index()
		{
            var towns = await  unitOfWork.Towns.GetAllAsync();

            ViewBag.Towns = towns;
            return View();
		}

		[HttpPost]
		public async Task<ActionResult> Index(string city, int days)
		{
            var towns = await unitOfWork.Towns.GetAllAsync();

            ViewBag.Towns = towns;
            if (!string.IsNullOrWhiteSpace(city))
			{
				Forecast forecast = await weatherService.Get(city, days);
				Request request = new Request
				{
					RequestTown = forecast.city,
					RequestDays = days,
					RequestDate = forecast.GetDailyList()[0].date,
					RequestImg = forecast.GetDailyList()[0].icon,
					RequestTemp = forecast.GetDailyList()[0].day 
				};
				await unitOfWork.Requests.CreateAsync(request);
				return View(forecast);
			}
			return View();
		}
	}
}
