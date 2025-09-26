using WeatherAPI_MAUI.Services;
using WeatherAPI_MAUI.ViewModels;


namespace WeatherAPI_MAUI.Views;

public partial class WeatherPage : ContentPage
{

	public WeatherPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void Swiped(object sender, SwipedEventArgs e)
    {
        Application.Current.MainPage = new ForecastPage(MainViewModel.Instance);
    }
}