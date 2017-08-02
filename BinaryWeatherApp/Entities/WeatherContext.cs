using BinaryWeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BinaryWeatherApp.Entities
{
	public class WeatherContext : DbContext
	{
		public WeatherContext(string connectionString) : base (connectionString)
		{

		}

		public DbSet<Town> Towns { get; set; }
		public DbSet<Request> Requests { get; set; }
	}

	public class DbInitializer : DropCreateDatabaseIfModelChanges<WeatherContext>
	{
		protected override void Seed(WeatherContext db)
		{
			db.Towns.Add(new Town { TownName = "Kiev" });
			db.Towns.Add(new Town { TownName = "Lviv" });
			db.Towns.Add(new Town { TownName = "Kharkiv" });
			db.Towns.Add(new Town { TownName = "Dnipropetrovsk" });
			db.Towns.Add(new Town { TownName = "Odessa" });

			db.SaveChanges();
		}
	}
}