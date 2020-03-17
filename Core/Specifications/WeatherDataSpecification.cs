using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class WeatherDataSpecification : BaseSpecification<WeatherData>
    {
        public WeatherDataSpecification() : base(m => m.Id > 0)
        {

        }

        public WeatherDataSpecification(DateTime dateTime)
            : base(m => m.dt.Date == dateTime.Date)
        {

        }
    }
}
