using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Platform;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI_MAUI.Models;
using WeatherAPI_MAUI.Services;
using WeatherAPI_MAUI.Views;
using static System.Net.WebRequestMethods;

namespace WeatherAPI_MAUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private static volatile MainViewModel instance;
        private static object syncRoot = new Object();

        public static MainViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MainViewModel();
                        }
                    }
                }
                return instance;
            }
        }

        public string SelectedCity { get; set; } = "Таганрог";
        public MainViewModel()
        {
            UpdateData(SelectedCity);
        }
        public IEnumerable<Hour> HoursForToday { get; set; }

        public IEnumerable<Forecastday> DaysWeek { get; set; }

        [ObservableProperty]
        private string citySearch;

        [ObservableProperty]
        private string imageIcon;

        [ObservableProperty]
        private string lblCity;

        [ObservableProperty]
        private string lblDicript;

        [ObservableProperty]
        private string windSpeed;

        [ObservableProperty]
        private string temp;

        [ObservableProperty]
        private string minTemp;

        [ObservableProperty]
        private string humidity;

        [ObservableProperty]
        private ObservableCollection<Hour> cvWeather;

        [ObservableProperty]
        private ObservableCollection<Forecastday> cvForecast;

        [ObservableProperty]
        private string hourImageIcon;

        [ObservableProperty]
        private string hourTemp;

        [ObservableProperty]
        private string dayTime;

        public async Task UpdateData(string citySearch)
        {
            if (string.IsNullOrEmpty(citySearch)) return;

            var today = DateTime.Now.ToString("yyyy-MM-dd");

            LblCity = citySearch;

            Root res = await ApiService.GetWeather(citySearch);
            if (res != null) 
            {
                ImageIcon = "https:" + res.current.condition.icon;

                LblDicript = res.current.condition.text;

                WindSpeed = res.current.wind_kph + " км/ч";

                Temp = res.current.temperature + "/";

                MinTemp = res.forecast.forecastday.First().day.mintemperature + "°С"; ;

                Humidity = res.current.humidity + "%";

                Forecastday todaysForecast = res.forecast?.forecastday?.FirstOrDefault(day => day.date == today);

                if (todaysForecast != null && todaysForecast.hour != null)
                {
                    HoursForToday = todaysForecast.hour;
                }
                else
                {
                    HoursForToday = Enumerable.Empty<Hour>();
                }

                CvWeather = new ObservableCollection<Hour>(HoursForToday);

                IEnumerable<Forecastday> weekForecasts = res.forecast?.forecastday?.Where(day => day.date != today) ?? Enumerable.Empty<Forecastday>();

                DaysWeek = weekForecasts;

                CvForecast = new ObservableCollection<Forecastday>(DaysWeek);
            }
            else 
            {
                LblCity = "Ошибка ввода";
                ImageIcon = "https://img.icons8.com/?size=150&id=nSDIlLXl1J3E&format=png&color=000000";
                LblDicript = "Попробуйте ввести заново";

                WindSpeed = "0";

                Temp = "0/";

                MinTemp = "0"; ;

                Humidity = "0";

                CvWeather = null;
            }

            SelectedCity = citySearch;

        }

        [RelayCommand]
        public async Task CityClick()
        {
            LblCity = CitySearch;
            await UpdateData(LblCity);
        }

    }
    
}
