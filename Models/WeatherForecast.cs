namespace Hackathon_Feature_Flagging.Models
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public string Temperature { get; set; }

        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}