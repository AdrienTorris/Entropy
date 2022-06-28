namespace PeriodicTimerLabApp.WebApp.Services
{
    public class WeatherForecastBackgroundService: BackgroundService
    {
        private readonly PeriodicTimer timer = new(TimeSpan.FromMilliseconds(1000));

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested
                && await timer.WaitForNextTickAsync(cancellationToken))
            {
                await LogWeatherForecastAsync();
            }
        }

        private static async Task LogWeatherForecastAsync()
        {
            Console.WriteLine(string.Concat("WeatherForecastBackgroundService: ", DateTime.Now.ToString("O")));
            await Task.Delay(500);
        }
    }
}
