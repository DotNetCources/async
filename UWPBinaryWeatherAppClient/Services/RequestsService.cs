using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPBinaryWeatherAppClient.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace UWPBinaryWeatherAppClient.Services
{
    public class RequestsService
    {
        private string ApiPath;
        private HttpClient client;
        public RequestsService()
        {
            ApiPath = "http://localhost:59524/api/";
            client = new HttpClient();
        }
        public async Task<IEnumerable<RequestsModel>> Get ()
        {
            var response = await client.GetAsync($"{ApiPath}Requests");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<RequestsModel>>(result);
        }
    }
}
