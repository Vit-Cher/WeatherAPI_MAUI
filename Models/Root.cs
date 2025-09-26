using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI_MAUI.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Astro
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string moonrise { get; set; }
        public string moonset { get; set; }
        public string moon_phase { get; set; }
        public int moon_illumination { get; set; }
        public int is_moon_up { get; set; }
        public int is_sun_up { get; set; }
    }

    public class Condition
    {
        public string text { get; set; }
        public string icon { get; set; }

        public string fullicon => string.Format("https:" + icon);

        public int code { get; set; }
    }

    public class Current
    {
        public string last_updated { get; set; }
        public decimal temp_c { get; set; }

        public decimal temperature => Math.Round(temp_c);

        public int is_day { get; set; }
        public Condition condition { get; set; }
        public decimal wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public decimal pressure_mb { get; set; }
        public decimal precip_mm { get; set; }
        public int humidity { get; set; }
        public int cloud { get; set; }
        public decimal feelslike_c { get; set; }
        public decimal windchill_c { get; set; }
        public decimal heatindex_c { get; set; }
        public decimal dewpoint_c { get; set; }
        public decimal vis_km { get; set; }
        public decimal uv { get; set; }
        public decimal gust_kph { get; set; }
    }

    public class Day
    {
        public decimal maxtemp_c { get; set; }
        public decimal maxtemperature => Math.Round(maxtemp_c);
        public decimal mintemp_c { get; set; }

        public decimal mintemperature => Math.Round(mintemp_c);
        public decimal avgtemp_c { get; set; }

        public decimal temperature => Math.Round(avgtemp_c);

        public decimal maxwind_kph { get; set; }
        public decimal totalprecip_mm { get; set; }
        public decimal totalsnow_cm { get; set; }
        public decimal avgvis_km { get; set; }
        public int avghumidity { get; set; }
        public int daily_will_it_rain { get; set; }
        public int daily_chance_of_rain { get; set; }
        public int daily_will_it_snow { get; set; }
        public int daily_chance_of_snow { get; set; }
        public Condition condition { get; set; }
    }

    public class Forecast
    {
        public List<Forecastday> forecastday { get; set; }
    }

    public class Forecastday
    {
        public string date { get; set; }
        public string FormattedDate => DateTime.Parse(date).ToString("M");
        public string WeekDay => DateTime.Parse(date).ToString(", dddd");
        public Day day { get; set; }
        public Astro astro { get; set; }
        public List<Hour> hour { get; set; }
    }

    public class Hour
    {
        public string time { get; set; }

        public string hoursOnly => DateTime.Parse(time).ToString("HH:mm");
        public decimal temp_c { get; set; }

        public decimal temperature => Math.Round(temp_c);

        public int is_day { get; set; }
        public Condition condition { get; set; }
        public decimal wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public decimal pressure_mb { get; set; }
        public decimal precip_mm { get; set; }
        public decimal snow_cm { get; set; }
        public int humidity { get; set; }
        public int cloud { get; set; }
        public decimal feelslike_c { get; set; }
        public decimal windchill_c { get; set; }
        public decimal heatindex_c { get; set; }
        public int will_it_rain { get; set; }
        public int chance_of_rain { get; set; }
        public int will_it_snow { get; set; }
        public int chance_of_snow { get; set; }
        public decimal vis_km { get; set; }
        public decimal gust_kph { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public string tz_id { get; set; }
        public int localtime_epoch { get; set; }
        public string localtime { get; set; }
    }

    public class Root
    {
        public Location location { get; set; }
        public Current current { get; set; }
        public Forecast forecast { get; set; }
    }


}
