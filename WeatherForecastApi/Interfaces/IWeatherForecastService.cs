﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastApi.ViewModels;

namespace WeatherForecastApi.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecastViewModel> GetWeatherForecastDetail();
        Task<DarkSkyWeatherForecastViewModel> GetDarkSkyWeatherForecastDetail();
    }
}
