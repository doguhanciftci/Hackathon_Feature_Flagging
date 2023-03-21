using Hackathon_Feature_Flagging.Domain;
using Hackathon_Feature_Flagging.Models;

namespace Hackathon_Feature_Flagging.Domain.Services
{
    public class WeatherForecastServiceFahrenheit : IWeatherForecastService
    {
        private readonly string[] _summaries;

        public WeatherForecastServiceFahrenheit(string[] summaries)
        {
            _summaries = summaries;
        }

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            var rng = new Random();

            return Enumerable.Range(1, 5).Select(index =>
            {
                int temperatuInCelcius = Random.Shared.Next(-20, 55);
                return new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Temperature = (temperatuInCelcius / 0.5556 + 32).ToString("N2") + " Fahrenheit",
                    Summary = _summaries[Random.Shared.Next(_summaries.Length)]
                };
            })
            .ToArray();
        }
    }
}
