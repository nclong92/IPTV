using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<WeatherData> Weathers { get; set; }
        public DbSet<FiveDaysWeatherData> FiveDaysWeathers { get; set; }
        public DbSet<DarkSkyWeather> DarkSkyWeathers { get; set; }
        public DbSet<DarkSkyDailyWeather> DarkSkyDailyWeathers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherData>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<FiveDaysWeatherData>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<DarkSkyWeather>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<DarkSkyDailyWeather>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
