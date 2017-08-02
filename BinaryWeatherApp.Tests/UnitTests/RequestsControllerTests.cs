using BinaryWeatherApp.Controllers;
using BinaryWeatherApp.Models;
using BinaryWeatherApp.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BinaryWeatherApp.Tests.UnitTests
{
	[TestFixture]
	class RequestsControllerTests
	{

		Mock<IRepository<Town>> _repository;
		IUnitOfWork _unitOfWork;
		RequestsController _controller;

		[SetUp]
		public void Setup()
		{
			_repository = new Mock<IRepository<Town>>();
			_unitOfWork = new UnitOfWork();
			_controller = new RequestsController(_unitOfWork);

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
		public void Index_View_Contains_ICollection_Of_Requests()
		{
			//Act
			var result = ((ViewResult)_controller.Index()).Model;

			//Assert
			Assert.IsInstanceOf<ICollection<Request>>(result);
		}

	}
}

