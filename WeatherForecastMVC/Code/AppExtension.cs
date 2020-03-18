using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastMVC.Interfaces;
using WeatherForecastMVC.Services;

namespace WeatherForecastMVC.Code
{
    public static class AppExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration Configuration)
        {
            #region Db config
            //var connection = Configuration.GetConnectionString("AppContext");
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            #endregion

            return services;
        }
    }
}
