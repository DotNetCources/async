using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UWPBinaryWeatherAppClient.Models;
using UWPBinaryWeatherAppClient.Services;

namespace UWPBinaryWeatherAppClient.ViewModels
{
    public class WeatherViewModel : ViewModelBase
    {
        public WeatherModel Forecast { get; set; }
        public ICommand ForecastCommand { get; set; }
        public ObservableCollection<string> Towns { get; private set; }
        public string city { get; set; }
        public int days { get; set; }

        public WeatherViewModel()
        {
            ForecastCommand = new RelayCommand(GetForecast);
            Towns = new ObservableCollection<string>();
            Forecast = new WeatherModel();
            MessengerInstance.Register<ObservableCollection<TownsModel>>(this, list => { Reload(); });
            Reload();

        }
        void Reload()
        {
            Towns.Clear();
            var townsService = new TownsService();
            var townsList = townsService.Get();
            foreach (var n in townsList)
                Towns.Add(n.TownName);
        }
        public async void GetForecast()
        {
            var service = new WeatherService();
            Forecast = await service.GetForecast(city, days);
            RaisePropertyChanged(() => Forecast);
            MessengerInstance.Send(new WeatherModel());
        }
    }
}
