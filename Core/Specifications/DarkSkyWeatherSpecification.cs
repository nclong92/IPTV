using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class DarkSkyWeatherSpecification : BaseSpecification<DarkSkyWeather>
    {
        public DarkSkyWeatherSpecification()
            : base(m => m.Id > 0)
        {

        }

        public DarkSkyWeatherSpecification(long timeMin, long timeMax, TodayType type)
            : base(m => m.time >= timeMin && m.time <= timeMax && m.Type == type)
        {

        }
    }
}
