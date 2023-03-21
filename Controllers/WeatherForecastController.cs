using Dapper;
using Hackathon_Feature_Flagging.Data;
using Hackathon_Feature_Flagging.Models;
using Hackathon_Feature_Flagging.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_Feature_Flagging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastServiceFactory _factory;
        private readonly FlagRepository _flagRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastServiceFactory factory, FlagRepository flagRepository)
        {
            _logger = logger;
            _factory = factory;
            _flagRepository = flagRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            Flag weatherFlag = _flagRepository.GetFlag(1);

            IWeatherForecastService weatherForecastService = _factory.GetWeatherForecastService(Enum.Parse<WeatherForecastServiceTypes>(weatherFlag.Opt));

            return weatherForecastService.GetWeatherForecasts();
        }
    }
}