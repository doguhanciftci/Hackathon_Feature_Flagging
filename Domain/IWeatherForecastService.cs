﻿using Hackathon_Feature_Flagging.Models;

namespace Hackathon_Feature_Flagging.Domain
{
    public interface IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> GetWeatherForecasts();
    }
}
