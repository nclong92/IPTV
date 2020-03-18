using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastMVC.ViewModels;

namespace WeatherForecastMVC.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecastViewModel> GetWeatherForecast();
    }
}
