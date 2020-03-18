using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastApi.Code.Extensions
{
    public static class Extensions
    {
        public static string ToWeatherIconUrl(this string image)
        {
            if (string.IsNullOrEmpty(image))
                return string.Empty;

            return $"{ApiSettings.ResourceServer}/{image}.png";
        }
    }
}
