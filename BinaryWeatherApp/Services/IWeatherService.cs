using BinaryWeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BinaryWeatherApp.Services
{
	public interface IWeatherService
	{
		Task<Forecast> Get(string city, int days);
	}
}