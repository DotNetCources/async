using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BinaryWeatherApp.Models
{
	public class Town
	{
		public int TownId { get; set; }
		public string TownName { get; set; }
	}
}