using WeatherAPI_MAUI.ViewModels;
using WeatherAPI_MAUI.Views;

namespace WeatherAPI_MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var mainViewModel = MainViewModel.Instance;

            return new Window(new WeatherPage(mainViewModel));
        }
    }
}