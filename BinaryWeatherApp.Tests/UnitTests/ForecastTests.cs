using BinaryWeatherApp.Models;
using BinaryWeatherApp.Services;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryWeatherApp.Tests.UnitTest
{
	[TestFixture]
	public class ForecastTests
	{	
		[Test]
		[TestCase(null,ExpectedResult = null)]
		[TestCase("", ExpectedResult = null)]
		public  Forecast WeatherService_Get_Returns_Null_When_City_Is_Empty (string city)
		{
			//Arrange
			var service = new WeatherService();

			//Act
			var result = service.Get(city, 1);

			//Assert
			return result;

		}
		
	}
}
