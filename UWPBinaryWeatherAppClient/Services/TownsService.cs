using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UWPBinaryWeatherAppClient.Models;
using System.Net.Http;

namespace UWPBinaryWeatherAppClient.Services
{
    public class TownsService
    {
        private string apiPath;
        private HttpClient client;
        public TownsService()
        {
            apiPath = "http://localhost:59524/api/";
            client = new HttpClient();
        }

        public async Task<IEnumerable<TownsModel>> Get()
        {
            var response = await client.GetAsync($"{apiPath}Towns");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<TownsModel>>(result);
        }

        public async Task Add(string name)
        {
            await client.PostAsync($"{apiPath}Towns/?name={name}",null);
        }

        public async Task Delete(string name)
        {
            await client.DeleteAsync($"{apiPath}Towns/?name={name}");
        }
    }
}
