using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastApi.Code
{
    public class ApiSettings
    {
        public static SymmetricSecurityKey JwtIssuerSigningKey
        {
            get
            {
                return new SymmetricSecurityKey(Encoding.UTF8.GetBytes("IPTVIssuerSigningKey20200316HmacSha256"));
            }
        }

        public static string JwtIssuer
        {
            get
            {
                return "ChamCongIssuer";
            }
        }

        public static string JwtAudience
        {
            get
            {
                return "ChamCongAudience";
            }
        }

        public static string ResourceServer { get; set; }
        public static string TimeSchedule { get; set; }

        public static string Version { get; set; }
        public static string Url { get; set; }
        public static string Note { get; set; }
        public static string PackageName { get; set; }
    }
}
