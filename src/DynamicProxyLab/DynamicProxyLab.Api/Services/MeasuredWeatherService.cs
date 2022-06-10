using System.Diagnostics;

namespace DynamicProxyLab.Api.Services
{
    public class MeasuredWeatherService : IWeatherService
    {
        private readonly ILogger<MeasuredWeatherService> _logger;
        private readonly IWeatherService _weatherService;

        public MeasuredWeatherService(ILogger<MeasuredWeatherService> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        public WeatherForecast[] GetForecast()
        {
            var sw = Stopwatch.StartNew();
            try
            {
                return _weatherService.GetForecast();
            }
            finally
            {
                sw.Stop();
                _logger.LogInformation("{MethodName} took {Duration}ms to complete", nameof(GetForecast), sw.ElapsedMilliseconds);
            }
        }
    }
}
