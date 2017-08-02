using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BinaryWeatherApp.Models;
using BinaryWeatherApp.Entities;
using System.Threading.Tasks;

namespace BinaryWeatherApp.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private WeatherContext db;
		private TownsRepository townsRepository;
		private RequestsRepository requestsRepository;

		public UnitOfWork(string connectionString)
		{
			db = new WeatherContext(connectionString);

		}
		public UnitOfWork()
		{
			db = new WeatherContext("WeatherContext");

		}

		public IRepository<Request> Requests
		{
			get
			{
				if (requestsRepository == null)
					requestsRepository = new RequestsRepository(db);
				return requestsRepository;
			}
		}


		public IRepository<Town> Towns
		{
			get
			{
				if (townsRepository == null)
					townsRepository = new TownsRepository(db);
				return townsRepository;
			}
		}

		public async Task Save()
		{
			await db.SaveChangesAsync();
		}

		private bool disposed = false;

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					db.Dispose();
				}
				this.disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
