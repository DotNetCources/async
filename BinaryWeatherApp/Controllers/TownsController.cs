using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BinaryWeatherApp.Repositories;
using BinaryWeatherApp.Models;
using System.Threading.Tasks;

namespace BinaryWeatherApp.Controllers
{
	public class TownsController : Controller
	{
		IUnitOfWork unitOfWork;
		public TownsController(IUnitOfWork itr)
		{
			unitOfWork = itr;
		}
		public async Task<ActionResult> Index()
		{
			var towns = await unitOfWork.Towns.GetAllAsync();
			return View(towns);
		}
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpGet]
		public async Task<ActionResult> Edit (int id)
		{
			var town = await unitOfWork.Towns.GetByIdAsync(id);
			return View(town);
		}

		[HttpPost]
		public async Task<ActionResult> Create(Town item)
		{
			if (ModelState.IsValid && !string.IsNullOrWhiteSpace(item.TownName))
			{
				Town town = new Town()
				{
					TownName = item.TownName
				};
				await unitOfWork.Towns.CreateAsync(town);
				return RedirectToAction("Index");
			}
			else
			{
				return View(item);
			}
		}
		
		[HttpPost]
		public async Task<ActionResult> Edit(Town item)
		{
			if (ModelState.IsValid && !string.IsNullOrWhiteSpace(item.TownName))
			{
				await unitOfWork.Towns.EditAsync(item);
				return RedirectToAction("Index");
			}
			else
			{
				return View(item);
			}
		}
		public async Task<ActionResult> Delete(int id)
		{
			await unitOfWork.Towns.DeleteAsync(id);
			return RedirectToAction("Index");
		}
	}
}
