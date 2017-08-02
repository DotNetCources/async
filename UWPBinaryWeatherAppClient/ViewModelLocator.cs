using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UWPBinaryWeatherAppClient.ViewModels;


namespace UWPBinaryWeatherAppClient
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary> 
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            //Register your services used here
            SimpleIoc.Default.Register<INavigationService, NavigationService>();

            // Register services 


            SimpleIoc.Default.Register<WeatherViewModel>();
            SimpleIoc.Default.Register<TownsViewModel>();
            SimpleIoc.Default.Register<RequestsViewModel>();

        }

        // <summary>
        // Gets the Requests view model.
        // </summary>
        // <value>
        // The Requests view model.
        // </value>
        public RequestsViewModel HistoryVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RequestsViewModel>();
            }
        }

        // <summary>
        // Gets the Weather view model.
        // </summary>
        // <value>
        // The Weather view model.
        // </value>
        public WeatherViewModel WeatherVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WeatherViewModel>();
            }
        }

        // <summary>
        // Gets the Towns view model.
        // </summary>
        // <value>
        // The Towns view model.
        // </value>
        public TownsViewModel TownsVWInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TownsViewModel>();
            }
        }

        // <summary>
        // The cleanup.
        // </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }

}