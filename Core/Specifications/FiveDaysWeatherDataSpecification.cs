using Common.Extensions;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class FiveDaysWeatherDataSpecification : BaseSpecification<FiveDaysWeatherData>
    {
        public FiveDaysWeatherDataSpecification() : base(m => m.Id > 0)
        {

        }

        public FiveDaysWeatherDataSpecification(string dateStr, double dateUnix)
            : base(m => m.dt_txt.Contains(dateStr) && m.dt_unix >= dateUnix)
        {

        }

        public FiveDaysWeatherDataSpecification(double time_unix)
            : base(m => m.dt_unix >= time_unix)
        {

        }

        public FiveDaysWeatherDataSpecification(string dateStr)
            : base(m => m.dt_txt.Contains(dateStr))
        {

        }
    }
}
