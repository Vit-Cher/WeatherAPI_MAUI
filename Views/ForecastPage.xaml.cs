using WeatherAPI_MAUI.Services;
using WeatherAPI_MAUI.ViewModels;

namespace WeatherAPI_MAUI.Views;

public partial class ForecastPage : ContentPage 
{ 
    public ForecastPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm; // »спользуем переданный экземпл€р
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await (BindingContext as MainViewModel)?.UpdateData((BindingContext as MainViewModel).SelectedCity);
    }

    private void Swiped(object sender, SwipedEventArgs e)
    {
        Application.Current.MainPage = new WeatherPage(MainViewModel.Instance);
    }
} 