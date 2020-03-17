using Common.Extensions;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastApi.Interfaces;
using WeatherForecastApi.ViewModels;

namespace WeatherForecastApi.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IAsyncRepository<WeatherData> _weatherDataRepository;
        private readonly IAsyncRepository<FiveDaysWeatherData> _fiveDaysWeatherDataRepository;

        public WeatherForecastService(IAsyncRepository<WeatherData> weatherDataRepository,
            IAsyncRepository<FiveDaysWeatherData> fiveDaysWeatherDataRepository)
        {
            _weatherDataRepository = weatherDataRepository;
            _fiveDaysWeatherDataRepository = fiveDaysWeatherDataRepository;
        }

        public async Task<WeatherForecastViewModel> GetWeatherForecastDetail()
        {
            var now = DateTime.Now;
            var nowStr = now.ToViDate3();
            var now_unix = now.DateTimeToUnixTimestamp();

            var weatherDataSpec = new WeatherDataSpecification(now);
            var todayWeathers = await _weatherDataRepository.ListAsync(weatherDataSpec);
            var currentWeather = todayWeathers.OrderByDescending(m => m.Id).FirstOrDefault();

            var todayWeatherDetail = await _fiveDaysWeatherDataRepository.ListAsync(new FiveDaysWeatherDataSpecification(nowStr, now_unix));
            var todayWeatherDetailVm = new List<TodayWeatherDetailViewModel>();

            todayWeatherDetailVm.Add(new TodayWeatherDetailViewModel()
            {
                Time = $"Now",
                Temp = Math.Round(currentWeather.temp),
                Icon = currentWeather.icon
            });

            foreach (var item in todayWeatherDetail)
            {
                var timeStr = item.dt_txt;
                var timeDate = timeStr.ToViDate3();

                if (timeDate.HasValue)
                {
                    todayWeatherDetailVm.Add(new TodayWeatherDetailViewModel(item));
                }
            }

            var dayWeatherVm = new List<DayWeatherViewModel>();
            var dayWeatherTempVm = new DayWeatherViewModel()
            {
                Icon = currentWeather.icon,
                TempMax = Math.Round(currentWeather.temp_max),
                TempMin = Math.Round(currentWeather.temp_min)
            };

            for (var date = now.Date; date < now.AddDays(7); date = date.AddDays(1))
            {
                var dt_unixDouble = now.DateTimeToUnixTimestamp();
                var spec = new FiveDaysWeatherDataSpecification(date.ToViDate3(), dt_unixDouble);
                var dayWeather = await _fiveDaysWeatherDataRepository.GetSingleBySpecAsync(spec);

                if (dayWeather != null)
                {
                    var dayWeathers = await _fiveDaysWeatherDataRepository.ListAsync(spec);
                    double temp_max_Temp = 0;
                    double temp_Min_Temp = 0;
                    var listTempMax = new List<double>();
                    var listTempMin = new List<double>();

                    foreach (var item in dayWeathers)
                    {
                        listTempMax.Add(item.temp_max);
                        listTempMin.Add(item.temp_min);
                    }

                    if (listTempMax != null && listTempMin != null)
                    {
                        temp_max_Temp = listTempMax.Max();
                        temp_Min_Temp = listTempMin.Min();
                    }

                    var dayWeatherTempVm2 = new DayWeatherViewModel()
                    {
                        Date = date,
                        DateDayOfWeek = date.DayOfWeek.ToString(),
                        Icon = dayWeather.icon,
                        TempMax = Math.Round(temp_max_Temp),
                        TempMin = Math.Round(temp_Min_Temp)
                    };

                    dayWeatherVm.Add(dayWeatherTempVm2);
                    dayWeatherTempVm = dayWeatherTempVm2;
                }
                else
                {
                    dayWeatherVm.Add(new DayWeatherViewModel()
                    {
                        Date = date,
                        DateDayOfWeek = date.DayOfWeek.ToString(),
                        Icon = dayWeatherTempVm.Icon,
                        TempMax = Math.Round(dayWeatherTempVm.TempMax),
                        TempMin = Math.Round(dayWeatherTempVm.TempMin)
                    });
                }
            }

            return new WeatherForecastViewModel()
            {
                CurrentWeather = new CurrentWeatherViewModel(currentWeather),
                TodayWeatherDetail = todayWeatherDetailVm,
                DayWeather = dayWeatherVm
            };
        }
    }
}
