using UWPBinaryWeatherAppClient.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace UWPBinaryWeatherAppClient
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Frame.Navigate(typeof(WeatherView));
        }

        private void WeatherNavigate(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WeatherView));

        }

        private void TownsNavigate(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(typeof(TownsView));
        }

        private void RequestsNavigate(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RequestsView));
        }
    }
}
