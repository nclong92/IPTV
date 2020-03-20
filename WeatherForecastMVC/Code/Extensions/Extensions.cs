using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastMVC.Code.Extensions
{
    public static class Extensions
    {
        public static string ToWeatherIconUrl(this string image)
        {
            if (string.IsNullOrEmpty(image))
                return string.Empty;

            return $"{AppConstants.ResourceServer}/{image}.png";
        }
    }
}
