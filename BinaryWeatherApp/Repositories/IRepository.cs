using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BinaryWeatherApp.Repositories
{
	public interface IRepository<T> :IDisposable
		where T : class
	{
		Task<List<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task CreateAsync(T item);
		Task DeleteAsync(int id);
		Task EditAsync(T item);
		Task SaveAsync();
		Task DeleteAllAsync();
	}
}
