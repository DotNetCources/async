using BinaryWeatherApp.Models;
using BinaryWeatherApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BinaryWeatherApp.ApiControllers
{
	public class TownsController : ApiController
	{
		IUnitOfWork unitOfWork;
		public TownsController(IUnitOfWork iuow)
		{
			unitOfWork = iuow;
		}
		public TownsController()
		{
			unitOfWork = new UnitOfWork("WeatherContext");
		}

        // Post api/Towns/?name=TownName
        [HttpPost]
		public async Task<HttpResponseMessage> Create(string name)
		{
			if (!string.IsNullOrWhiteSpace(name))
			{
				await unitOfWork.Towns.CreateAsync(new Town { TownName = name });
				return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };
			}
			return new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };
		}

		//Get api/Towns
		[HttpGet]
		public async Task<List<Town>> GetAll()
		{
			return await  unitOfWork.Towns.GetAllAsync();
		}

		//Delete api/Towns/id
		[HttpDelete]
		public async Task<HttpResponseMessage> Delete(int id)
		{
			if (unitOfWork.Towns.GetByIdAsync(id) != null)
			{
				await unitOfWork.Towns.DeleteAsync(id);
				return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };
			}
			return new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };
		}

        //Delete api/Towns/?name=TownName
        [HttpDelete]
		public async Task<HttpResponseMessage> Delete(string name)
		{
			var town = (await unitOfWork.Towns.GetAllAsync()).FirstOrDefault(x => x.TownName == name);
			if (town != null)
			{
				await unitOfWork.Towns.DeleteAsync(town.TownId);
				return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };
			}
			return new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };
		}

	}
}
