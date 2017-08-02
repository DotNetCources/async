using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BinaryWeatherApp.Models
{
	public class Request
	{
		public int RequestId { get; set; }
		public string RequestTown { get; set; }
		public string RequestDate { get; set; }
		public int RequestDays { get; set; }
		public double RequestTemp { get; set; }
		public string RequestImg { get; set; }
	}
}