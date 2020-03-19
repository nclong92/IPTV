using Common.Extensions;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastApi.Code.Extensions;

namespace WeatherForecastApi.ViewModels
{
    public class DarkSkyWeatherForecastViewModel
    {
        public DarkSkyCurrentWeatherViewModel CurrentWeather { get; set; }
        public List<DarkSkyTodayWeatherDetailViewModel> TodayWeatherDetail { get; set; }
        public List<DarkSkyDayWeatherViewModel> DayWeather { get; set; }
    }

    public class DarkSkyDayWeatherViewModel
    {
        public DarkSkyDayWeatherViewModel()
        {

        }

        public DateTime Date { get; set; }
        public string DateDayOfWeek { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }
        public string Icon { get; set; }

        public string IconUrl
        {
            get
            {
                return Icon.ToWeatherIconUrl();
            }
        }

    }

    public class DarkSkyCurrentWeatherViewModel
    {
        public DarkSkyCurrentWeatherViewModel()
        {

        }

        public DarkSkyCurrentWeatherViewModel(DarkSkyWeather darkSkyWeather, string city, string countryCode)
        {
            City = city;
            Country = countryCode;
            Temp = darkSkyWeather.temperature;
            Description = darkSkyWeather.summary;
            Icon = darkSkyWeather.icon;
        }

        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public double Temp { get; set; }
        public string Icon { get; set; }

        public string IconUrl
        {
            get
            {
                return Icon.ToWeatherIconUrl();
            }
        }
    }

    public class DarkSkyTodayWeatherDetailViewModel
    {
        public DarkSkyTodayWeatherDetailViewModel()
        {

        }

        public DarkSkyTodayWeatherDetailViewModel(DarkSkyWeather darkSkyWeather)
        {
            var timeLong = darkSkyWeather.time;
            var time = timeLong.UnixTimestampToLocalDateTimeLong().ToViHour4();

            Time = time;
            Temp = Math.Round(darkSkyWeather.temperature);
            Icon = darkSkyWeather.icon;
        }

        public static List<DarkSkyTodayWeatherDetailViewModel> GetList(IEnumerable<DarkSkyWeather> darkSkyWeathers)
        {
            return darkSkyWeathers.Select(m => new DarkSkyTodayWeatherDetailViewModel(m)).ToList();
        }

        public string Time { get; set; }
        public double Temp { get; set; }
        public string Icon { get; set; }

        public string IconUrl
        {
            get
            {
                return Icon.ToWeatherIconUrl();
            }
        }
    }
}
