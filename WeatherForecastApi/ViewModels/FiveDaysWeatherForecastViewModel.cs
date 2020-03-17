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
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public double Temp { get; set; }
        public string Icon { get; set; }
    }

    public class TodayWeatherDetailViewModel
    {
        public string Time { get; set; }
        public double Temp { get; set; }
        public string Icon { get; set; }
    }
}
