using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastMVC.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherForecastMVC.Controllers
{
    public class WeatherController : BaseController
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        public async Task<IActionResult> Index()
        {
            var weatherForecastData = await _weatherForecastService.GetWeatherForecast();

            return View(weatherForecastData);
        }
    }
}
