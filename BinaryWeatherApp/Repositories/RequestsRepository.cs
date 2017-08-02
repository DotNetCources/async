using BinaryWeatherApp.Entities;
using BinaryWeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BinaryWeatherApp.Repositories
{
	public class RequestsRepository : IRepository<Request>
	{
		private WeatherContext db;
		private bool dispose = false;

		public RequestsRepository(WeatherContext weathercontext)
		{
			db = weathercontext;
		}

		public async Task<List<Request>> GetAllAsync()
		{
			return await  db.Requests.ToListAsync();
		}

		public async Task<Request> GetByIdAsync(int id)
		{
			return await db.Requests.FindAsync(id);
		}
		public async Task CreateAsync(Request request)
		{
			db.Requests.Add(request);
			await SaveAsync();
		}
		public async Task DeleteAsync(int id)
		{
			Request item = await db.Requests.FindAsync(id);
			if (item != null)
				db.Requests.Remove(item);
			await SaveAsync();
		}
		public async Task EditAsync(Request item)
		{
			db.Entry(item).State = EntityState.Modified;
			await SaveAsync();
		}
		public async Task DeleteAllAsync()
		{
			db.Towns.RemoveRange(db.Towns);
			await db.SaveChangesAsync();
		}
		public async Task SaveAsync()
		{
			await db.SaveChangesAsync();
		}

		public virtual void Dispose(bool disposing)
		{
			if (!dispose)
			{
				if (disposing)
				{
					db.Dispose();
				}
			}
			dispose = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}