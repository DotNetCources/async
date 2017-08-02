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
	public class TownsRepository : IRepository<Town>
	{
		private WeatherContext db;
		private bool dispose = false;

		public TownsRepository(WeatherContext weathercontext)
		{
			db = weathercontext;
		}
		public async Task<List<Town>> GetAllAsync()
		{
			return await db.Towns.ToListAsync();
		}
		public async Task<Town> GetByIdAsync (int id)
		{
			return await db.Towns.FindAsync(id);
		}
		public async Task  CreateAsync (Town town)
		{
			db.Towns.Add(town);
			await SaveAsync();
		}
		public async Task EditAsync(Town item)
		{
			db.Entry(item).State = EntityState.Modified;
			await SaveAsync();
		}
		public async Task DeleteAsync (int id)
		{
			Town item = await db.Towns.FindAsync(id);
			if (item != null)
				db.Towns.Remove(item);
			await SaveAsync();
		}
		public async Task DeleteAllAsync()
		{
			db.Towns.RemoveRange(db.Towns);
			await SaveAsync();
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