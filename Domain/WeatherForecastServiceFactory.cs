using Hackathon_Feature_Flagging.Domain.Services;

namespace Hackathon_Feature_Flagging.Domain
{
    public class WeatherForecastServiceFactory
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastServiceFactory()
        {

        }

        public IWeatherForecastService GetWeatherForecastService(WeatherForecastServiceTypes type)
        {

            switch (type)
            {
                case WeatherForecastServiceTypes.Celcius:
                    return new WeatherForecastServiceCelcius(Summaries);

                case WeatherForecastServiceTypes.Fahrenheit:
                    return new WeatherForecastServiceFahrenheit(Summaries);

                case WeatherForecastServiceTypes.Kelvin:
                    return new WeatherForecastServiceKelvin(Summaries);

                default:
                    return new WeatherForecastServiceCelcius(Summaries);
            }
        }

    }
}
