using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastMVC.Code;
using WeatherForecastMVC.Code.Helpers;
using WeatherForecastMVC.Interfaces;
using WeatherForecastMVC.ViewModels;

namespace WeatherForecastMVC.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly ILogger<WeatherForecastService> _logger;

        public WeatherForecastService(ILogger<WeatherForecastService> logger)
        {
            _logger = logger;
        }

        public async Task<WeatherForecastViewModel> GetWeatherForecast()
        {
            var uriString = "";
            uriString = AppConstants.WebApiHostUrl;

            var responseData = await HttpClientHelper.GetResponseFromUrl(uriString);
            var apiResult = JsonConvert.DeserializeObject<WeatherForecastViewModel>(responseData);

            return apiResult;
        }

        public async Task<DarkSkyWeatherForecastViewModel> GetDarkSkyWeatherForecast()
        {
            var uriString = "";
            uriString = AppConstants.DarkSkyWeatherApiHostUrl;

            var responseData = await HttpClientHelper.GetResponseFromUrl(uriString);
            if (responseData == null || responseData.Trim() == "" || string.IsNullOrEmpty(responseData.Trim()))
                return null;

            try
            {
                var apiResult = JsonConvert.DeserializeObject<DarkSkyWeatherForecastViewModel>(responseData);

                return apiResult;
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetDarkSkyWeatherForecast {ex.Message}");
            }

            return null;
        }
    }
}
