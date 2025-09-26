using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using WeatherAPI_MAUI.Models;
using WeatherAPI_MAUI.Views;


namespace WeatherAPI_MAUI.Services
{
    public static class ApiService
    {

        public static async Task<Root> GetWeather(string cityName)
        {
            var httpClient = new HttpClient();
            try
            {
                string response = await httpClient.GetStringAsync($"https://api.weatherapi.com/v1/forecast.json?q={cityName}&days=11&lang=ru&key=b578e5f8fb474c1a82065729252509");

                Root result = JsonConvert.DeserializeObject<Root>(response);

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        
    }
}
