using System.Collections.Generic;
using NUnit.Framework;
using BinaryWeatherApp.Repositories;
using BinaryWeatherApp.Controllers;
using FakeItEasy;
using BinaryWeatherApp.Models;
using System.Web.Mvc;
using Moq;

namespace BinaryWeatherApp.Tests.UnitTest
{
	[TestFixture]
	class TownsControllerTests
	{
		Mock<IRepository<Town>> _repository;
		IUnitOfWork _unitOfWork;
		TownsController _controller;

		[SetUp]
		public void Setup()
		{
			_repository = new Mock<IRepository<Town>>();
			_unitOfWork = new UnitOfWork();
			_controller = new TownsController(_unitOfWork);

			_repository.Setup(x => x.GetAll())
				.Returns(new List<Town>
				{
					new Town{TownId = 1, TownName = "Kharkov"}
				});
		}

		[TearDown]
		public void TestTearDown()
		{
			_repository.Reset();
		}

		[Test]
		public void Edit_When_Valid_Data_Then_RedirectToAction()
		{
			//Arrange
			var _controller = new TownsController(_unitOfWork);

			//Act
			var res = _controller.Edit(new Town() { TownId = 1, TownName = "Kharkov" });

			//Assert
			Assert.IsInstanceOf<RedirectToRouteResult>(res);
		}

		[Test]
		public void Edit_When_Invalid_Data_Then_ViewResult()
		{
			// Arrange
			_controller.ModelState.AddModelError("CityName", "Required");

			//Act
			var res = _controller.Edit(new Town());

			//Assert
			Assert.IsInstanceOf<ViewResult>(res);
		}


	}
}
