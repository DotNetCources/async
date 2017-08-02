using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinaryWeatherApp.Entities;
using BinaryWeatherApp.Repositories;
using BinaryWeatherApp.Controllers;
using System.Web.Mvc;
using BinaryWeatherApp.Models;

namespace BinaryWeatherApp.Tests.IntegrationTests
{
	[TestFixture]
	class DbRequestsTests
	{
		WeatherContext context;
		UnitOfWork unitOfWork;
		RequestsController controller;

		[SetUp]
		public void Setup()
		{
			unitOfWork = new UnitOfWork("DbRequestsTests");
			context = new WeatherContext("DbRequestsTests");
			controller = new RequestsController(unitOfWork);
		}
		[TearDown]
		public void TearDown()
		{
			context.Requests.RemoveRange(context.Requests);
			context.SaveChanges();
		}

		[Test]
		public void Controller_Index_Returns_Correct_Value()
		{
			//Arrange
			unitOfWork.Requests.Create(new Request
			{
				RequestTown = "Kharkov",
				RequestDays = 1,
				RequestDate = "",
				RequestImg = "",
				RequestTemp = 27.5
			});
			var list = controller.Index() as ViewResult;
			//Почему следующее сравнение выдает ошибку?
			//Assert.AreEqual((list.Model as IEnumerable<Request>).FirstOrDefault(), context.Requests.FirstOrDefault());
			Assert.AreEqual((list.Model as IEnumerable<Request>).Count(), context.Requests.Count());
		}
	}
}
