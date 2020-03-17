using Common.Extensions;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastApi.ViewModels
{
    public class WeatherForecastViewModel
    {
        public CurrentWeatherViewModel CurrentWeather { get; set; }
        public List<TodayWeatherDetailViewModel> TodayWeatherDetail { get; set; }
        public List<DayWeatherViewModel> DayWeather { get; set; }
    }

    public class DayWeatherViewModel
    {
        public DayWeatherViewModel()
        {

        }

        public DateTime Date { get; set; }
        public string DateDayOfWeek { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }
        public string Icon { get; set; }
        //public string IconURL { get { 
        //    return } }

    }

    public class CurrentWeatherViewModel
    {
        public CurrentWeatherViewModel()
        {

        }

        public CurrentWeatherViewModel(WeatherData weatherData)
        {
            City = weatherData.name;
            Country = weatherData.country;
            Temp = Math.Round(weatherData.temp);
            Description = weatherData.description;
            Icon = weatherData.icon;
        }

        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public double Temp { get; set; }
        public string Icon { get; set; }
    }

    public class TodayWeatherDetailViewModel
    {
        public TodayWeatherDetailViewModel()
        {

        }

        public TodayWeatherDetailViewModel(FiveDaysWeatherData data)
        {
            var timeStr = data.dt_txt;
            var timeDate = timeStr.ToViDate3();

            Time = timeDate.Value.ToViHour3();
            Temp = Math.Round(data.temp);
            Icon = data.icon;
        }

        public string Time { get; set; }
        public double Temp { get; set; }
        public string Icon { get; set; }
    }
}
