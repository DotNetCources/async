using NUnit.Framework;
using BinaryWeatherApp.Repositories;
using BinaryWeatherApp.Controllers;
using BinaryWeatherApp.Models;
using BinaryWeatherApp.Entities;
using System.Linq;

namespace BinaryWeatherApp.Tests.IntegrationTests
{
	[TestFixture]
	class DbTownsTests
	{
		WeatherContext context;
		UnitOfWork unitOfWork;
		TownsController controller;

		[SetUp]
		public void Setup()
		{			
			unitOfWork = new UnitOfWork("DbTownsTests");
			context = new WeatherContext("DbTownsTests");
			controller = new TownsController(unitOfWork);
		}
		[TearDown]
		public void TearDown()
		{
			context.Towns.RemoveRange(context.Towns);
			context.SaveChanges();
		}

		[Test]
		public void Create_When_Data_Not_Valid_Does_Nothing ()
		{
			//Act
			controller.Create(new Town());

			//Assert
			Assert.AreEqual(0, context.Towns.Count());
		}

		[Test]
		public void Create_With_Valid_Model_Does_Create_Object()
		{
			//Arrange
			Town town = new Town {TownId = 1, TownName = "Kharkov" };

			//Act
			controller.Create(town);

			//Assert
			Assert.AreEqual(1, context.Towns.Count());
		}

		[Test]
		public void Delete_With_Wrong_Id_Doesnt_Change_Db ()
		{
			//Arrange
			controller.Create(new Town { TownId = 1, TownName = "Kharkov" });

			//Act
			controller.Delete(2);

			//Assert
			Assert.AreEqual(1, context.Towns.Count());

		}
		[Test]
		public void Delete_With_Correct_Id_Changes_Db()
		{
			//Arrange
			Town town = new Town { TownId = 1, TownName = "Kharkov" };
			controller.Create(town);

			//Act

			controller.Delete(context.Towns.FirstOrDefault(x => x.TownName == "Kharkov").TownId);

			//Arrange
			Assert.AreEqual(0,context.Towns.Count());
		}

	}
}
