using BinaryWeatherApp.Repositories;
using BinaryWeatherApp.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BinaryWeatherApp
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private IKernel kernel;
		public NinjectDependencyResolver(IKernel kernelParam)
		{
			kernel = kernelParam;
			AddBindings();
		}
		public object GetService(Type serviceType)
		{
			return kernel.TryGet(serviceType);
		}
		public IEnumerable<object> GetServices(Type serviceType)
		{
			return kernel.GetAll(serviceType);
		}
		private void AddBindings()
		{
			kernel.Bind<IWeatherService>().To<WeatherService>();
			kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

		}
	}
}