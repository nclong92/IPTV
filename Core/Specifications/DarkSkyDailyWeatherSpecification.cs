using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class DarkSkyDailyWeatherSpecification : BaseSpecification<DarkSkyDailyWeather>
    {
        public DarkSkyDailyWeatherSpecification()
            : base(m => m.Id > 0)
        {

        }

        public DarkSkyDailyWeatherSpecification(long timeMin, long timeMax)
            : base(m => m.time >= timeMin && m.time <= timeMax)
        {

        }
    }
}
