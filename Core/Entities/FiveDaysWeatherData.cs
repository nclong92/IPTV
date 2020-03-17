using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class FiveDaysWeatherData : BaseEntityWithDate
    {
        public double dt_unix { get; set; }
        public string dt_txt { get; set; }
        public string name { get; set; }

        public string lon { get; set; }
        public string lat { get; set; }

        public string description { get; set; }
        public string icon { get; set; }

        public double temp { get; set; }
        public string feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public string pressure { get; set; }
        public string humidity { get; set; }

        public string windspeed { get; set; }
        public string winddeg { get; set; }

        public string country { get; set; }
    }
}
