using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPBinaryWeatherAppClient.Models;
using UWPBinaryWeatherAppClient.Services;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace UWPBinaryWeatherAppClient.ViewModels
{
    public class RequestsViewModel : ViewModelBase
    {
        public ObservableCollection<RequestsModel> Requests { get; set; }

        public RequestsViewModel()
        {
            Requests = new ObservableCollection<RequestsModel>();
            Reload();
            MessengerInstance.Register<WeatherModel>(this, list => { Reload(); });
        }
        public void Reload()
        {
            var service = new RequestsService();
            Requests.Clear();
            var list = service.Get().ToListAsync().Result;
            list.Reverse();

            foreach (var x in list)
                Requests.Add(x);
        }
    }
}
