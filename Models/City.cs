using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI_MAUI.Models
{
    public class City
    {
        public string CityName { get; set; }
    

         public static List<City> RuCity = new List<City>()
         {
            new City { CityName = "Москва" }, 
            new City { CityName = "Санкт-Петербург" },
            new City { CityName = "Новосибирск" },
            new City { CityName = "Екатеринбург" },
            new City { CityName = "Казань" },
            new City { CityName = "Ростов" },
            new City { CityName = "Таганрог" },
            new City { CityName = "Тюмень" },
            new City { CityName = "Анапа" },
            new City { CityName = "Сочи" },
            new City { CityName = "Новороссийск" },
            new City { CityName = "Шахты" },
            new City { CityName = "Урюпинск" },
            new City { CityName = "Уфа" },
            new City { CityName = "Красноярск" },
            new City { CityName = "Волгоград" },
            new City { CityName = "Самара" },
            new City { CityName = "Пермь" },
            new City { CityName = "Саратов" },
            new City { CityName = "Владивосток" },
            new City { CityName = "Томск" },
         };

    } 
}