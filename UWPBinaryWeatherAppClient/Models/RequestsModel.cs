using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPBinaryWeatherAppClient.Models
{
    public class RequestsModel
    {
        public int RequestId { get; set; }
        public string RequestTown { get; set; }
        public string RequestDate { get; set; }
        public int RequestDays { get; set; }
        public double RequestTemp { get; set; }
        public string RequestImg { get; set; }
    }
}