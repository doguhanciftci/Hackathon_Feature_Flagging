using Hackathon_Feature_Flagging.Data;
using Hackathon_Feature_Flagging.Domain;
using Hackathon_Feature_Flagging.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_Feature_Flagging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastServiceFactory _serviceFactory;
        private readonly FlagRepository _flagRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastServiceFactory serviceFactory, FlagRepository flagRepository)
        {
            _logger = logger;
            _serviceFactory = serviceFactory;
            _flagRepository = flagRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            Flag weatherFlag = _flagRepository.GetFlag(1);

            IWeatherForecastService weatherForecastService = _serviceFactory.GetWeatherForecastService(Enum.Parse<WeatherForecastServiceTypes>(weatherFlag.VALUE));

            return weatherForecastService.GetWeatherForecasts();
        }
    }
}