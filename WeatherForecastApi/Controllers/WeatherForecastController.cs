﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherForecastApi.Interfaces;

namespace WeatherForecastApi.Controllers
{
    [Route("api/weatherforecast")]
    public class WeatherForecastController : BaseController
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> GetWeather()
        {
            var result = await _weatherForecastService.GetWeatherForecastDetail();

            if(result == null)
            {
                return Ok("Error: Cannot get weather. Please try again later.");
            }

            return Ok(result);
        }

        [Route("getdarkskyweather")]
        [HttpGet]
        public async Task<IActionResult> GetDarkSkyWeather()
        {
            var result = await _weatherForecastService.GetDarkSkyWeatherForecastDetail();

            if (result == null)
            {
                return Ok("Error: Cannot get darksky api weather. Please try again later.");
            }

            return Ok(result);
        }
    }
}
